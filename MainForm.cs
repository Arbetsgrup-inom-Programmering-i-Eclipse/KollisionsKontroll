using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows;
using System.Security.Cryptography;
using VMS.TPS.Common.Model.Types;
using System.Security.Policy;
using System.Windows.Documents;

namespace KollisionsKontroll
{
    public partial class MainForm : Form
    {
        private PlanSetup _plan;
        private Structure _bord;
        private Structure _body;
        private Structure _Target;
        private ElementPosition ipp0;
        private double rad = 390;
        public static void Main(PlanSetup plan)
        {
            System.Windows.Forms.Application.Run(new MainForm(plan));
        }
        public MainForm(PlanSetup plan)
        {
            InitializeComponent();
            _plan = plan;
            _bord = _plan.StructureSet.Structures.FirstOrDefault(s => s.Id == "CouchSurface"); //definierar bordet från planen
            _body = _plan.StructureSet.Structures.FirstOrDefault(s => s.DicomType == "EXTERNAL");//definierar body från planen
            _Target = _plan.StructureSet.Structures.FirstOrDefault(s => s.DicomType == "PTV");//definierar PTV från planen
            InitializeGUI();
            ipp0 = chKollision.ChartAreas[0].InnerPlotPosition;//Definierar positionen för grafen

        }
        private void InitializeGUI()
        {
            var xSize = Math.Round(_plan.StructureSet.Image.XSize / 100d, 0) * 100; //ta fram storleken på bilden i x
            var ySize = Math.Round(_plan.StructureSet.Image.YSize / 100d, 0) * 100; //ta fram storleken på bilden i y

            double padding = 300; //buffert för storleken på diagrammet eftersom gantryrotationen kan vara utanför bildstorleken
            var ca = chKollision.ChartAreas[0];
            ca.AxisX.Maximum = xSize / 2 + padding; //definierar pixelmatrisens x max
            ca.AxisY.Maximum = ySize / 2 + padding; //definierar pixelmatrisens y max
            ca.AxisX.Minimum = -xSize / 2 - padding; //definierar pixelmatrisens x min
            ca.AxisY.Minimum = -ySize / 2 - padding; //definierar pixelmatrisens y min
            ca.AxisY.IsReversed = true;

            ca.AxisX.MinorGrid.Enabled = true;
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisX.MinorGrid.LineWidth = 1;
            ca.AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
            ca.AxisX.MinorGrid.Interval = 50; //gridstorlek x

            ca.AxisY.MinorGrid.Enabled = true;
            ca.AxisY.MajorGrid.Enabled = false;
            ca.AxisY.MinorGrid.LineWidth = 1;
            ca.AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
            ca.AxisY.MinorGrid.Interval = 50; //gridstorlek x

            ca.AxisX.Interval = 50; //gridstorlek y
            ca.AxisY.Interval = 50; //gridstorlek y

            VVector isoPos = _plan.StructureSet.Image.DicomToUser(_plan.Beams.First().IsocenterPosition, _plan); //gör om iso pos till eclipse coord från DICOM

            txtLatIso.Text = (isoPos.x / 10).ToString("0.00"); //skriv in x koord i cm med 2 decimaler i GUI
            txtVRTiso.Text = (isoPos.y / 10).ToString("0.00"); //skriv in y koord i cm med 2 decimaler i GUI

            chKollision.Series.Add("iso"); //skapa serie (ritning) för höger armbåge
            chKollision.Series.Add("Höger Armbåge"); //skapa serie (ritning) för höger armbåge
            chKollision.Series.Add("Vänster Armbåge"); //skapa serie (ritning) för höger armbåge
            chKollision.Series.Add("Body"); //skapa serie (ritning) för Body
            chKollision.Series.Add("PTV"); //skapa serie (ritning) för PTV
            chKollision.Series.Add("Gantry"); //skapa serie (ritning) för Gantry
            chKollision.Series.Add("bord"); //skapa serie (ritning) för bord
            chKollision.Series["iso"].ChartType = SeriesChartType.Bubble; //definierar vilken typ av graf för iso
            chKollision.Series["Body"].ChartType = SeriesChartType.FastPoint; //definierar vilken typ av graf för Body
            chKollision.Series["PTV"].ChartType = SeriesChartType.FastPoint; //definierar vilken typ av graf för PTV
            chKollision.Series["Gantry"].ChartType = SeriesChartType.Line; //definierar vilken typ av graf för Gantry
            chKollision.Series["bord"].ChartType = SeriesChartType.FastPoint; //definierar vilken typ av graf för bord

            chKollision.Series["iso"].Color = Color.Red; //definierar vilken typ av graf för iso
            chKollision.Series["Body"].Color = Color.Orange; //definierar vilken typ av graf för Body
            chKollision.Series["PTV"].Color = Color.Blue; //definierar vilken typ av graf för PTV
            chKollision.Series["Gantry"].Color = Color.Red; //definierar vilken typ av graf för Gantry
            chKollision.Series["bord"].Color = Color.Fuchsia; //definierar vilken typ av graf för bord

            chKollision.Series["iso"].Points.AddXY(isoPos.x, isoPos.y); //lägger till punkten för iso

            UpdateStructure();//ritar alla strukturer som finns i planen, bord, body, PTV baserat på Isopositionen
        }

        private void UpdateStructure() //ritar alla strukturer som finns i planen, bord, body, PTV baserat på Isopositionen
        {
            double x, y, xIso, yIso; //skapar x, y, xIso, yIso

            if (CheckTextInput(txtLatIso.Text, out xIso) && CheckTextInput(txtVRTiso.Text, out yIso)) //om x och y kan omvandlas till siffor, kör vidare
            {
                VVector isoPos = new VVector(xIso, yIso, _plan.StructureSet.Image.DicomToUser(_plan.Beams.First().IsocenterPosition, _plan).z);//Hämtar isopos. baserat på input + z från planen
                if (_bord != null) //Kontrollerar om bord är inlagt
                {
                    RitaStruktur(isoPos, _bord, "bord", true); //ritar bord
                }
                else
                    System.Windows.MessageBox.Show("Hittade ingen bordstruktur");

                if (_body != null && _Target != null) //Kontrollerar om body + target är inlagt
                {
                    RitaStruktur(isoPos, _body, "Body", false); //ritar body
                    RitaStruktur(isoPos, _Target, "PTV", false); //ritar body
                }
                else
                    System.Windows.MessageBox.Show("Hittade ingen body eller PTV");
            }
        }
        private void UpdateChart() //Uppdaterar grafen med alla ritningar
        {
            chKollision.Series["iso"].Points.Clear(); //rensar tidigare isopunkt i diagram
            UpdateStructure(); //ritar alla strukturer som finns i planen, bord, body, PTV
            this.chKollision.Invalidate(); //rensar grafrutan
            this.chKollision.Update(); //uppdaterar grafrutan
            RitaArmbågar("Höger Armbåge", txtArmLatDx.Text, txtArmVrtDx.Text, grpArmDx, lblArmDx); //Ritar höger armbåge
            RitaArmbågar("Vänster Armbåge", "-" + txtArmLatSin.Text, txtArmVrtSin.Text, grpArmSin, lblArmSin);//Ritar vänster armbåge
        }
        private void RitaArmbågar(string ser, string lat, string vrt, GroupBox grpArm, Label label)//Ritar en armbåga i grafen baserat på input
        {
            var s = chKollision.Series[ser]; //väljer serien som matats in i funktionen
            s.Points.Clear(); //rensar serie

            double x, y, xIso, yIso; //skapar tom x, y, xIso, yIso

            if (CheckTextInput(txtLatIso.Text, out xIso) && CheckTextInput(txtVRTiso.Text, out yIso)) //kontrollerar om x och y kan omvandlas till siffor
            {
                if (CheckTextInput(lat, out x) && CheckTextInput(vrt, out y)) //om x och y kan omvandlas till siffor
                {
                    s.Points.AddXY(-x, -y); //lägg till armbågens pos i diagram. - tecknet är för att koord för strukturerna är upp och ner annars.
                    s.ChartType = SeriesChartType.Point; //definiera vilken typ av punkt
                    s.MarkerSize = 15; //definiera vilken typ av punkt

                    //var UO = _plan.StructureSet.Image.UserOrigin;
                    //var xdiff_UO = x + UO.x;
                    //var ydiff_UO = y - UO.y;

                    double dist = GetDistance(-x, -y, xIso, yIso); //räknar ut avståndet till gantryt
                    CheckDist(grpArm, label, dist, "Armbågen är "); //kontrollerar om avståndet är okej
                }
            }
        }
        private void RitaStruktur(VVector isoPos, Structure strukt, string serie, bool isBord)//Ritar struktur i diagramet
        {
            double minDist = 999; //deklarerar minsta avståndet
            double tempDist = 0; //deklarerar avståndet
            

            VMS.TPS.Common.Model.API.Image img = _plan.StructureSet.Image; //deklarerar bildunderlaget
            var isoDCM = img.UserToDicom(isoPos, _plan); //definierar dicom iso baserat på uppdaterat iso
            int imagePlane = Convert.ToInt32(Math.Round((isoDCM.z - img.Origin.z) / img.ZRes)); //hittar index för planet för iso

            var contourOnImagePlane = strukt.GetContoursOnImagePlane(imagePlane).First(); //Hämtar strukturens kontur på planet för iso

            if (isBord)
            {
                double bordLong = 100;
                double angle = 15;
                double a = Math.Atan(angle) * bordLong;
                for (int i = 0; i < contourOnImagePlane.Length; i++)
                {
                    contourOnImagePlane[i].x += a;
                }
            }

            foreach (var point in contourOnImagePlane) //går igenom varje punkt från strukturen i planet
            {
                VVector contourUser = img.DicomToUser(point, _plan); //tar fram punkten i eclipse koord
                chKollision.Series[serie].Points.AddXY(contourUser.x, contourUser.y); //Ritar punkt i diagrammet i Eclipse koord
                if (isBord) //om det är bordet som ritas räknas avståndet till gantryt ut
                {
                    tempDist = GetDistance(contourUser.x, contourUser.y, isoPos.x, isoPos.y); //Räknar ut avståndet till gantryt 
                    if (tempDist < minDist)
                    {
                        minDist = tempDist;
                    }
                }
            }
            if (isBord)
                CheckDist(grpBord, lblBord, minDist, "Bordskanten är "); //kontrollerar avståndet till gantryt från bordet
        }
        private void chKollision_PrePaint(object sender, ChartPaintEventArgs e) //uppdaterar grafen när GUI har ändrats/skapats
        {
            RitaIsoAndGantry(e); //Ritar iso och gantrycirkeln
        }
        private void RitaIsoAndGantry(ChartPaintEventArgs e) //skapar iso punkt och cirkel runt som motsvarar gantry
        {
            double x, y; //skapar x, y

            if (CheckTextInput(txtLatIso.Text, out x) && CheckTextInput(txtVRTiso.Text, out y)) //om x och y kan omvandlas till siffor, kör vidare
            {
                chKollision.Series["iso"].Points.AddXY(x, y); //lägg till iso koord i diagram
                chKollision.Series["iso"].ChartType = SeriesChartType.FastPoint; //definiera vilken typ av punkt

                ChartArea ca = chKollision.ChartAreas[0]; //plocka ut chartArea
                Axis ax = ca.AxisX; //hämta x axeln
                Axis ay = ca.AxisY; //hämta y axeln

                var s = chKollision.Series["iso"]; //definierar en 

                DataPoint dpCenter = s.Points[0];
                dpCenter.MarkerStyle = MarkerStyle.Circle; //definierar stilen för gantryt till cirkel

                float xRad = (float)(ax.ValueToPixelPosition(0) - ax.ValueToPixelPosition(rad));
                float yRad = (float)(ay.ValueToPixelPosition(0) - ay.ValueToPixelPosition(rad));

                float xc = (float)ax.ValueToPixelPosition(x);
                float yc = (float)ay.ValueToPixelPosition(y);

                Rectangle r = Rectangle.Round(new RectangleF(xc - xRad, yc - yRad, xRad * 2, yRad * 2));

                e.ChartGraphics.Graphics.DrawEllipse(Pens.Red, r); //Ritar cirkel baserat på radien.
            }
        }
        private static void CheckDist(GroupBox grpArm, Label label, double dist, string descText)
        {
            if (dist >= 3) //Över 3 cm från gantryt är det inga problem
                grpArm.BackColor = Color.LightGreen;
            else if (dist < 3 && dist > 1.5) //mellan 1.5 och 3 cm roterar gantryt långsamt
                grpArm.BackColor = Color.Yellow;
            else if (dist <= 1.5 && dist > 0) //mellan 0 och 1.5 cm behövs override
                grpArm.BackColor = Color.Orange;
            else //Under 0 cm krocker gantryt
                grpArm.BackColor = Color.Tomato;
            label.Text = descText + dist.ToString("0.00") + " cm från gantry"; //Skriver ut avståndet för strukturen i fråga med två decimaler
        }

        private bool CheckTextInput(string str, out double value) //kontrollerar om input är godkänt format (siffror)
        {
            bool ok = double.TryParse(str, out value);
            value = value * 10;
            return ok;
        }
        private double GetDistance(double x, double y, double xIso, double yIso) //Räknar ut avståndet mellan iso och punkt
        {
            double dist = (rad - Math.Sqrt(Math.Pow((x - xIso), 2) + Math.Pow((y - yIso), 2))) / 10; //Matte
            return dist;
        }
        private void btnReset_Click(object sender, EventArgs e) //Resettar grafen till ursprungsläge
        {
            chKollision.Series.Clear();
            InitializeGUI();
            UpdateChart();//Uppdaterar grafen med alla ritningar
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            UpdateChart();//Uppdaterar grafen med alla ritningar
        }
        private void txtLatIso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Om användaren klickar Enter
            {
                UpdateChart();//Uppdaterar grafen med alla ritningar
            }
        }
        private void txtVRTiso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Om användaren klickar Enter
            {
                UpdateChart();//Uppdaterar grafen med alla ritningar
            }
        }
        private void txtArmLatDx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Om användaren klickar Enter
            {
                UpdateChart();//Uppdaterar grafen med alla ritningar
            }
        }
        private void txtArmLatSin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Om användaren klickar Enter
            {
                UpdateChart();//Uppdaterar grafen med alla ritningar
            }
        }
        private void txtArmVrtDx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Om användaren klickar Enter
            {
                UpdateChart();//Uppdaterar grafen med alla ritningar
            }
        }
        private void txtArmVrtSin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Om användaren klickar Enter
            {
                UpdateChart();//Uppdaterar grafen med alla ritningar
            }
        }
        private void makeSquare(Chart chart)
        {
            ChartArea ca = chart.ChartAreas[0];

            // store the original value:
            //if (ipp0 == null) 

            // get the current chart area :
            ElementPosition cap = ca.Position;

            // get both area sizes in pixels:
            System.Drawing.Size CaSize = new System.Drawing.Size((int)(cap.Width * chart.ClientSize.Width / 100f),
                                    (int)(cap.Height * chart.ClientSize.Height / 100f));

            System.Drawing.Size IppSize = new System.Drawing.Size((int)(ipp0.Width * CaSize.Width / 100f),
                                    (int)(ipp0.Height * CaSize.Height / 100f));

            // we need to use the smaller side:
            int ippNewSide = Math.Min(IppSize.Width, IppSize.Height);

            // calculate the scaling factors
            float px = ipp0.Width / IppSize.Width * ippNewSide;
            float py = ipp0.Height / IppSize.Height * ippNewSide;

            // use one or the other:
            if (IppSize.Width < IppSize.Height)
                ca.InnerPlotPosition = new ElementPosition(ipp0.X, ipp0.Y, ipp0.Width, py);
            else
                ca.InnerPlotPosition = new ElementPosition(ipp0.X, ipp0.Y, px, ipp0.Height);
        }

        private void chKollision_Resize(object sender, EventArgs e)
        {
            makeSquare(chKollision);
        }
        private void chKollision_MouseClick(object sender, MouseEventArgs e)
        {
            var xv = chKollision.ChartAreas[0].AxisX.PixelPositionToValue(e.X) / 10;
            var yv = chKollision.ChartAreas[0].AxisY.PixelPositionToValue(e.Y) / 10;
            txtLatIso.Text = xv.ToString("0.00");
            txtVRTiso.Text = yv.ToString("0.00");
            UpdateChart();
            //System.Windows.MessageBox.Show("x = " + xv + "   y =" + yv);
        }
    }
}
