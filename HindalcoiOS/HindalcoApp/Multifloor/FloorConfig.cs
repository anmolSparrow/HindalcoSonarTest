using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Layout;

namespace HindalcoiOS.Multifloor
{
    public partial class FloorConfig : Form
    {
        public FloorConfig(int floorCount)
        {
            InitializeComponent();

            tablePanel = new TablePanel();

            tablePanel.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
                new TablePanelColumn(TablePanelEntityStyle.Relative, 33F),
                new TablePanelColumn(TablePanelEntityStyle.Relative, 33F),
                new TablePanelColumn(TablePanelEntityStyle.Relative, 34F)
                }
            );
            tablePanel.Location = new System.Drawing.Point(0, 0);
            tablePanel.Name = "tablePanel";
            tablePanel.Dock = DockStyle.Fill;
            tablePanel.TabIndex = 0;
            float ratio = 100 / floorCount;
            for (int i = 0; i < floorCount; i++)
            {
               tablePanel.Rows.Add(new TablePanelRow(TablePanelEntityStyle.Relative, ratio));
            }

            mainPanel.Controls.Add(tablePanel);
            mainPanel.SetRow(tablePanel, 1);
            mainPanel.SetColumn(tablePanel, 0);
            
        }

        private DevExpress.Utils.Layout.TablePanel tablePanel;
    }
}
