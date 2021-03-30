using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Object_Learning
{
    public partial class Form1 : Form
    {

        //Create overlay named " Name of overlay " 
        GMapOverlay overlay = new GMapOverlay("Name of overlay");
        // Create dict
        Dictionary<GMapMarker, MarkerDetail> markers = new Dictionary< GMapMarker, MarkerDetail>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add Usercontrol to main and then display it in panel1
            //UserControl1 control = new UserControl1();
            //panel1.Controls.Add(control);


            mainMap.Position = new PointLatLng(13.736717, 100.523186);
            mainMap.MaxZoom = 15;
            mainMap.MinZoom = 5;
            mainMap.Zoom = 8;

            // Has 3 mode. 
            mainMap.Manager.Mode = GMap.NET.AccessMode.ServerOnly;
            // Define Map service.
            mainMap.MapProvider = GMapProviders.GoogleMap;
            // add Overlay to map
            mainMap.Overlays.Add(overlay);
        }



        private void mainMap_MouseClick(object sender, MouseEventArgs e)
        {
            // MouseEventArgs is event args for MouseButton

            PointLatLng point = mainMap.FromLocalToLatLng(e.X, e.Y);

            // Mouse click event ( Form 1 )
            if (e.Button == MouseButtons.Left)
            {

                txtLat.Text = point.Lat.ToString();
                txtLng.Text = point.Lng.ToString();

            }
        }


        // Add fucntion
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var lattitude = double.Parse(txtLat.Text);
            var longtitude = double.Parse(txtLng.Text);
            var point = new PointLatLng(lattitude, longtitude);


            GMapMarker marker = new GMarkerGoogle(point,GMarkerGoogleType.red_dot);
            // Create tag for create marker

            MarkerDetail detail = new MarkerDetail();
            detail.id = 0;
            detail.name = txtName.Text;
            markers.Add(marker, detail);

            //marker.Tag = txtName.Text;
            //marker.ToolTipText = marker.Tag.ToString();
            //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            overlay.Markers.Add(marker);
            txtLat.Text = "";
            txtLng.Text = "";
            txtName.Text = "";

        }

        private void mainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            // Do not ness
            PointLatLng point = item.Position;

            // use args.Position instead
            txtLat.Text = item.Position.Lat.ToString();
            txtLng.Text = item.Position.Lng.ToString();
            txtName.Text = item.Tag.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }
    }
}
