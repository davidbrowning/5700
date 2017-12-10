using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GuiLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Update_Text()
        {
            Message_Queue m = Message_Queue.Instance;
            string s;
            string[,] p;
            m.MessageQueue.TryDequeue(out s);
            m.PuzzleMessageQueue.TryDequeue(out p);
            int height = (int)Math.Sqrt(p.Length);
            int width = height;
            dataGridView1.ColumnCount = width;

            for (int r = 0; r < height; ++r)
            {
                var row = dataGridView1.Rows[r];
                for (int co = 0; co < width; co++)
                {
                    if(row.Cells[co].Value.ToString() != p[r, co])
                    {
                        row.Cells[co].Value = p[r, co];
                    }
                }

            }
            Thread.Sleep(500);
            this.Update();
            Update_Text();
        }
        public void Start_Loop()
        {
            Message_Queue m = Message_Queue.Instance;
            string s;
            string[,] p;
            m.MessageQueue.TryDequeue(out s);
            m.PuzzleMessageQueue.TryDequeue(out p);
            int height = (int)Math.Sqrt(p.Length);
            int width = height;
            dataGridView1.ColumnCount = width;

            for (int r = 0; r < height; ++r)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                for (int co = 0; co < width; co++)
                {
                    row.Cells[co].Value = p[r, co];
                }

                this.dataGridView1.Rows.Add(row);
            }
            this.Update();
            Update_Text();
        }
    }
}
