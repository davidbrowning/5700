namespace GuiLayer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.messageQueueBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.messageQueueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.messageQueueBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.messageQueueBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageQueueBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageQueueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageQueueBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageQueueBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-2, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(910, 807);
            this.dataGridView1.TabIndex = 0;
            // 
            // messageQueueBindingSource3
            // 
            this.messageQueueBindingSource3.DataSource = typeof(GuiLayer.Message_Queue);
            // 
            // messageQueueBindingSource
            // 
            this.messageQueueBindingSource.DataSource = typeof(GuiLayer.Message_Queue);
            // 
            // messageQueueBindingSource1
            // 
            this.messageQueueBindingSource1.DataSource = typeof(GuiLayer.Message_Queue);
            // 
            // messageQueueBindingSource2
            // 
            this.messageQueueBindingSource2.DataSource = typeof(GuiLayer.Message_Queue);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(914, 812);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageQueueBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageQueueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageQueueBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageQueueBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource messageQueueBindingSource;
        private System.Windows.Forms.BindingSource messageQueueBindingSource3;
        private System.Windows.Forms.BindingSource messageQueueBindingSource1;
        private System.Windows.Forms.BindingSource messageQueueBindingSource2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

