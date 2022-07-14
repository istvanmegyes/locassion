using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Loccassion2._0
{
    public partial class MainMenu : Form
    {
        Serializer serializer = new Serializer();
        AbstractShape movedShape = null;
        AbstractShape resizedShape = null;
        PointF lastMouseLocation;
        Floor activeFloor;
        List<Floor> floors = new List<Floor>();
        int activeFloorIndex = 0;
        int activeShapeIndex;
        AbstractNode resizableNodePoint = null;
        string buildingName = "Épület1";
        
        public MainMenu()
        {
            Thread thread = new Thread(new ThreadStart(StartMainMenu));
            thread.Start();
            Thread.Sleep(3000);
            
            thread.Abort();
            
            InitializeComponent();
            floors.Add(new Floor());
            activeFloor = floors[activeFloorIndex];
            Text = $"{buildingName} - Locassion";
            if (activeFloorIndex==0)
            {
                LblFloorNumber.Text = "Földszint";
            }
            else
            {
                LblFloorNumber.Text = $"{activeFloorIndex}. emelet";
            }
            Invalidate();
        }

        public void StartMainMenu()
        {
            Application.Run(new StartUpWindow());
        }

        private void PictureBoxEditor_Paint(object sender, PaintEventArgs e)
        {
            if (activeFloor!=null)
            {
                foreach (var item in activeFloor.shapes)
                {
                    item.draw(e.Graphics, pictureBoxEditor.Width, pictureBoxEditor.Height, activeFloor);
                }
            }
            if (activeFloorIndex == 0)
            {
                LblFloorNumber.Text = "Földszint";
            }
            else
            {
                LblFloorNumber.Text = $"{activeFloorIndex}. emelet";
            }
            Console.WriteLine(activeFloorIndex);
        }

        private void PictureBoxEditor_MouseUp(object sender, MouseEventArgs e)
        {
            movedShape = null;
            resizableNodePoint = null;
            pictureBoxEditor.Invalidate();
        }

        private void PictureBoxEditor_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                resizedShape = activeFloor.shapes.Find(match => match.isInsideAbstractShape(e.Location));
                activeShapeIndex = activeFloor.shapes.FindIndex(match => match.isInsideAbstractShape(e.Location));
                Console.WriteLine(activeShapeIndex);
                if (resizedShape != null && resizedShape.isInsideAbstractShape(e.Location))
                {
                    resizedShape?.toggleShapeResize();
                }
            }
        }

        private void PictureBoxEditor_MouseMove(object sender, MouseEventArgs e)
        {
            PointF delta = new PointF();
            if (activeFloor!=null)
            {
                delta.X = (e.Location.X - lastMouseLocation.X) / activeFloor.camera.zoomLevel;
                delta.Y = (e.Location.Y - lastMouseLocation.Y) / activeFloor.camera.zoomLevel;

                if (resizedShape != null && resizedShape.resize)
                {
                    resizableNodePoint?.move(delta);
                }
                else
                {
                    if (movedShape == null) return;
                    movedShape.move(delta);
                }

                lastMouseLocation = e.Location;
                pictureBoxEditor.Invalidate();
            }
        }

        private void PictureBoxEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeFloor!=null)
            {
                if (e.Button != MouseButtons.Left) return;

                if (resizedShape != null && resizedShape.resize)
                {
                    resizableNodePoint = resizedShape.findActiveNode(e.Location); 
                }
                else
                {
                    movedShape = activeFloor.shapes.Find(match => match.isInsideAbstractShape(e.Location)); // lambda függvény - match rövíditése  - match (shape) paraméterű boolean visszatérésű fv
                }

                lastMouseLocation = e.Location;
                pictureBoxEditor.Invalidate();
            }
        }

        // Alakzatok létrehozásának kezdete
        private void BtnGenerateSquare_Click(object sender, EventArgs e)
        {
            activeFloor.addAbstractShape(Shape.createSquare(new PointF(210/activeFloor.camera.zoomLevel, 100/activeFloor.camera.zoomLevel), 100));
            pictureBoxEditor.Invalidate();
        }

        private void BtnGenerateTShape_Click(object sender, EventArgs e)
        {
            activeFloor.addAbstractShape(Shape.createTShape(new PointF(210 / activeFloor.camera.zoomLevel, 100 / activeFloor.camera.zoomLevel), 100));
            pictureBoxEditor.Invalidate();
        }

        private void BtnGenerateLShape_Click(object sender, EventArgs e)
        {
            activeFloor.addAbstractShape(Shape.createLShape(new PointF(210 / activeFloor.camera.zoomLevel, 100 / activeFloor.camera.zoomLevel), 100));
            pictureBoxEditor.Invalidate();
        }

        private void BtnGenerateUShape_Click(object sender, EventArgs e)
        {
            activeFloor.addAbstractShape(Shape.createUShape(new PointF(210 / activeFloor.camera.zoomLevel, 100 / activeFloor.camera.zoomLevel), 100));
            pictureBoxEditor.Invalidate();
        }

        private void BtnGenerateInteriorItem_Click(object sender, EventArgs e)
        {
            activeFloor.addAbstractShape(InteriorItem.createInteriorItem(new PointF(210 / activeFloor.camera.zoomLevel, 100 / activeFloor.camera.zoomLevel), 50, 70));
            pictureBoxEditor.Invalidate();
        }
        // Alakzatok létrehozásának vége


        private void BtnColorDialogShapeColor_Click(object sender, EventArgs e)
        {
            colorDialogShapeColor.ShowDialog();
            if (resizedShape != null) resizedShape.Color = colorDialogShapeColor.Color;
            pictureBoxEditor.Invalidate();
        }


        // Fájl kezelés kezdete
        private void BtnOpenProject_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if (serializer.Read(openFileDialog.FileName)!=null)
            {
                floors = serializer.Read(openFileDialog.FileName);
                activeFloor = floors[0];
                pictureBoxEditor.Invalidate();
            }
        }

        private void BtnSaveProject_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            serializer.Write(floors, saveFileDialog.FileName);
        }
        // Fájl kezelés vége


        private void BtnTxtBxChangeFloorName_Click(object sender, EventArgs e)
        {
            buildingName=textBoxRenameFloor.Text;
            Text = $"{buildingName} - Loccassion";
            Invalidate();
        }

        private void BtnZoomLevelIncrease_Click(object sender, EventArgs e)
        {
            if (activeFloor.camera.zoomLevel + 0.1f < 5.0f)
            {
                activeFloor.camera.zoomLevel += 0.1f;
                pictureBoxEditor.Invalidate();
            }
        }

        private void BtnZoomLevelDecrease_Click(object sender, EventArgs e)
        {
            if (activeFloor.camera.zoomLevel - 0.1f > 0.2f)
            {
                activeFloor.camera.zoomLevel -= 0.1f;
                pictureBoxEditor.Invalidate();
            }
        }

        private void BtnClockWiseRotateSelectedShape_Click(object sender, EventArgs e)
        {
            if (resizedShape != null) resizedShape.orientation += 5.0f;
            pictureBoxEditor.Invalidate();
        }

        private void BtnCounterClockWiseRotateSelectedShape_Click(object sender, EventArgs e)
        {
            if (resizedShape != null) resizedShape.orientation -= 5.0f;
            pictureBoxEditor.Invalidate();
        }

        private void BtnMoveCameraUp_Click(object sender, EventArgs e)
        {
            activeFloor.camera.position.Y -= 50;
            pictureBoxEditor.Invalidate();
        }

        private void BtnMoveCameraRight_Click(object sender, EventArgs e)
        {
            activeFloor.camera.position.X += 50;
            pictureBoxEditor.Invalidate();
        }

        private void BtnMoveCameraDown_Click(object sender, EventArgs e)
        {
            activeFloor.camera.position.Y += 50;
            pictureBoxEditor.Invalidate();
        }

        private void BtnMoveCameraLeft_Click(object sender, EventArgs e)
        {
            activeFloor.camera.position.X -= 50;
            pictureBoxEditor.Invalidate();
        }

        private void BtnNewProject_Click(object sender, EventArgs e)
        {
            floors = new List<Floor>();
            floors.Add(new Floor());
            activeFloorIndex = 0;
            activeFloor = floors[activeFloorIndex];
            resizableNodePoint = null;
            resizedShape = null;
            activeShapeIndex = -1;
            serializer = new Serializer();
            buildingName = "Épület1";
            pictureBoxEditor.Invalidate();
        }

        private void BtnDeleteAbstractShape_Click(object sender, EventArgs e)
        {
            if (activeShapeIndex!=-1)
            {
                activeFloor.shapes.RemoveAt(activeShapeIndex);
                activeShapeIndex = -1;
                pictureBoxEditor.Invalidate();
                if (resizedShape != null) resizedShape.toggleShapeResize();
                resizedShape = null;
            }
        }

        private void BtnIncreaseFloorNumber_Click(object sender, EventArgs e)
        {
            if (activeFloorIndex < floors.Count-1)
            {
                activeFloorIndex++;
                activeFloor = floors[activeFloorIndex];
                pictureBoxEditor.Invalidate();
            }
        }

        private void BtnDecreaseFloorNumber_Click(object sender, EventArgs e)
        {
            if (activeFloorIndex > 0)
            {
                activeFloorIndex--;
                activeFloor = floors[activeFloorIndex];
                pictureBoxEditor.Invalidate();
            }
        }

        private void BtnAddFloor_Click(object sender, EventArgs e)
        {
            floors.Add(new Floor());
        }
    }
}
