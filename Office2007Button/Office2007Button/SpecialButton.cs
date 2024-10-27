//Programmed by Turan Kent. All rights reserved...

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace Office2007Button
{
	/// <summary>
	/// Summary description for SpecialButton.
	/// </summary>
	public class SpecialButton : System.Windows.Forms.Label
	{
		private System.ComponentModel.IContainer components=null;
		private bool sp=false;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2; //special press button
		private Point locPoint;
		private System.Windows.Forms.Timer timer3;
		Rectangle recBounds;
		
		
		public SpecialButton()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer,true);
			this.UpdateStyles();
			
			// TODO: Add any initialization after the InitComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // SpecialButton
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(75, 25);
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Click += new System.EventHandler(this.SpecialButton_MouseLeave);
            this.Leave += new System.EventHandler(this.SpecialButton_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SpecialButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.SpecialButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SpecialButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SpecialButton_MouseUp);
            this.ParentChanged += new System.EventHandler(this.SpecialButton_ParentChanged);
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnPaint(PaintEventArgs pe)
		{
			// TODO: Add custom paint code here

			// Calling the base class OnPaint
			base.OnPaint(pe);
			if(this.sp==false)
			{
				
				this.DrawControl(pe.Graphics);
				
			}
			else
			{
				this.onDrawControl(pe.Graphics);
				
			}
			
			
		}
		#region Properties
		public bool PressedButton
		{
			get {return sp;}
			set 
			{ 
				sp = value;
				this.Invalidate();
			}
		}

		public Point AdjustImageLocation
		{
			get {return locPoint;}
			set 
			{ 
				locPoint = value;
				this.Invalidate();
			}
		}
		#endregion

		#region DrawControl

		internal void DrawControl(Graphics e)
		{
			recBounds = this.ClientRectangle;
			Rectangle m_BrushSize=new Rectangle(0, 0, 
				this.Width , this.Height / 2);
			
			for(int i=0;i<=40;i++)
			{
				
				LinearGradientBrush myLinearGradientBrush1 = new System.Drawing.Drawing2D.LinearGradientBrush(m_BrushSize, Color.FromArgb(i,220,252,255), Color.FromArgb(i,125,195,236),
					90);//top item

				LinearGradientBrush myLinearGradientBrush=new LinearGradientBrush(m_BrushSize, Color.FromArgb(i,93,174,221), Color.FromArgb(i,177,252,255),
					-90);//down item

				myLinearGradientBrush.WrapMode =System.Drawing.Drawing2D.WrapMode.TileFlipXY;
				myLinearGradientBrush1.WrapMode=System.Drawing.Drawing2D.WrapMode.TileFlipXY;
			
				e.FillRectangle(myLinearGradientBrush,1, this.Height/2, 
					this.Width-2 , this.Height / 2-1);//down


				e.FillRectangle(myLinearGradientBrush1,1, 1, 
					this.Width-2 , this.Height / 2);//top
				

				//Draw Border
				Brush brsBorder=new SolidBrush(Color.FromArgb(121,157,182));
				Pen pnsBorder=new Pen(brsBorder);

				Brush brsDot=new SolidBrush(Color.FromArgb(179,201,214));
				Pen pnsDot=new Pen(brsDot);

				e.DrawRectangle(Pens.White,this.ClientRectangle.X+1,this.ClientRectangle.Y+1,this.ClientRectangle.Width-3,this.ClientRectangle.Height-3);


				e.DrawLine(pnsDot,this.ClientRectangle.X,this.ClientRectangle.Y+1,this.ClientRectangle.X+1,this.ClientRectangle.Y+1);
				e.DrawLine(pnsDot,this.ClientRectangle.X,this.ClientRectangle.Bottom-2,this.ClientRectangle.X+1,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsDot,this.ClientRectangle.Right-1,this.ClientRectangle.Bottom-2,this.ClientRectangle.Right-2,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsDot,this.ClientRectangle.Right-1,this.ClientRectangle.Y+1,this.ClientRectangle.Right-2,this.ClientRectangle.Y+1);


				e.DrawLine(pnsBorder,this.ClientRectangle.X+1,this.ClientRectangle.Y,this.ClientRectangle.Right-2,this.ClientRectangle.Y);
				e.DrawLine(pnsBorder,this.ClientRectangle.X,this.ClientRectangle.Y+1,this.ClientRectangle.X,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsBorder,this.ClientRectangle.X+1,this.ClientRectangle.Bottom-1,this.ClientRectangle.Right-2,this.ClientRectangle.Bottom-1);
				e.DrawLine(pnsBorder,this.ClientRectangle.Right-1,this.ClientRectangle.Y+1,this.ClientRectangle.Right-1,this.ClientRectangle.Bottom-2);

//////////////////////////////////////////////////////////////////end Border
				
				
				OnDrawTextAndImage(e);
				myLinearGradientBrush.Dispose();
				myLinearGradientBrush1.Dispose();
				brsBorder.Dispose();
				brsDot.Dispose();
				pnsBorder.Dispose();
				pnsDot.Dispose();
				
			}
			
		}
		internal void onDrawControl(Graphics e)
		{
			recBounds = this.ClientRectangle;
			Rectangle m_BrushSize=new Rectangle(0, 0, 
				this.Width , this.Height / 2);
			
			for(int i=0;i<=40;i++)
			{
				
				LinearGradientBrush myLinearGradientBrush1 = new System.Drawing.Drawing2D.LinearGradientBrush(m_BrushSize, Color.FromArgb(i,255,253,235), Color.FromArgb(i,255,235,182),
					90);//top item

				LinearGradientBrush myLinearGradientBrush=new LinearGradientBrush(m_BrushSize, Color.FromArgb(i,255,214,56), Color.FromArgb(i,255,232,167),
					-90);//down item

				myLinearGradientBrush.WrapMode =System.Drawing.Drawing2D.WrapMode.TileFlipXY;
				myLinearGradientBrush1.WrapMode=System.Drawing.Drawing2D.WrapMode.TileFlipXY;
			
				e.FillRectangle(myLinearGradientBrush,1, this.Height/2, 
					this.Width-2 , this.Height / 2-1);//down


				e.FillRectangle(myLinearGradientBrush1,1, 1, 
					this.Width-2 , this.Height / 2);//top
				

				//Draw Border
				Brush brsBorder=new SolidBrush(Color.FromArgb(191,167,121));
				Pen pnsBorder=new Pen(brsBorder);

				Brush brsDot=new SolidBrush(Color.FromArgb(233,223,159));
				Pen pnsDot=new Pen(brsDot);

				e.DrawRectangle(Pens.White,this.ClientRectangle.X+1,this.ClientRectangle.Y+1,this.ClientRectangle.Width-3,this.ClientRectangle.Height-3);


				e.DrawLine(pnsDot,this.ClientRectangle.X,this.ClientRectangle.Y+1,this.ClientRectangle.X+1,this.ClientRectangle.Y+1);
				e.DrawLine(pnsDot,this.ClientRectangle.X,this.ClientRectangle.Bottom-2,this.ClientRectangle.X+1,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsDot,this.ClientRectangle.Right-1,this.ClientRectangle.Bottom-2,this.ClientRectangle.Right-2,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsDot,this.ClientRectangle.Right-1,this.ClientRectangle.Y+1,this.ClientRectangle.Right-2,this.ClientRectangle.Y+1);


				e.DrawLine(pnsBorder,this.ClientRectangle.X+1,this.ClientRectangle.Y,this.ClientRectangle.Right-2,this.ClientRectangle.Y);
				e.DrawLine(pnsBorder,this.ClientRectangle.X,this.ClientRectangle.Y+1,this.ClientRectangle.X,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsBorder,this.ClientRectangle.X+1,this.ClientRectangle.Bottom-1,this.ClientRectangle.Right-2,this.ClientRectangle.Bottom-1);
				e.DrawLine(pnsBorder,this.ClientRectangle.Right-1,this.ClientRectangle.Y+1,this.ClientRectangle.Right-1,this.ClientRectangle.Bottom-2);

				//////////////////////////////////////////////////////////////////end Border
				

				OnDrawTextAndImage(e);
				myLinearGradientBrush.Dispose();
				myLinearGradientBrush1.Dispose();
				brsBorder.Dispose();
				brsDot.Dispose();
				pnsBorder.Dispose();
				pnsDot.Dispose();
				
			}
			
		}
		
		internal void pressDrawControl(Graphics e)
		{
			recBounds = this.ClientRectangle;
			Rectangle m_BrushSize=new Rectangle(0, 0, 
				this.Width , this.Height / 2);
			
			for(int i=0;i<=40;i++)
			{
				
				LinearGradientBrush myLinearGradientBrush1 = new System.Drawing.Drawing2D.LinearGradientBrush(m_BrushSize, Color.FromArgb(i,244,185,127), Color.FromArgb(i,255,175,71),
					90);//top item

				LinearGradientBrush myLinearGradientBrush=new LinearGradientBrush(m_BrushSize, Color.FromArgb(i,255,151,8), Color.FromArgb(i,255,196,68),
					-90);//down item

				myLinearGradientBrush.WrapMode =System.Drawing.Drawing2D.WrapMode.TileFlipXY;
				myLinearGradientBrush1.WrapMode=System.Drawing.Drawing2D.WrapMode.TileFlipXY;
			
				e.FillRectangle(myLinearGradientBrush,1, this.Height/2, 
					this.Width-2 , this.Height / 2-1);//down


				e.FillRectangle(myLinearGradientBrush1,1, 1, 
					this.Width-2 , this.Height / 2);//top
				

				//Draw Border
				Brush brsBorder=new SolidBrush(Color.FromArgb(147,125,90));
				Pen pnsBorder=new Pen(brsBorder);

				Brush brsDot=new SolidBrush(Color.FromArgb(153,126,92));
				Pen pnsDot=new Pen(brsDot);
				
				
				Pen pnsInBorder=new Pen(Color.FromArgb(241,167,74));
				e.DrawRectangle(pnsInBorder,this.ClientRectangle.X+1,this.ClientRectangle.Y+1,this.ClientRectangle.Width-3,this.ClientRectangle.Height-3);


				e.DrawLine(pnsDot,this.ClientRectangle.X,this.ClientRectangle.Y+1,this.ClientRectangle.X+1,this.ClientRectangle.Y+1);
				e.DrawLine(pnsDot,this.ClientRectangle.X,this.ClientRectangle.Bottom-2,this.ClientRectangle.X+1,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsDot,this.ClientRectangle.Right-1,this.ClientRectangle.Bottom-2,this.ClientRectangle.Right-2,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsDot,this.ClientRectangle.Right-1,this.ClientRectangle.Y+1,this.ClientRectangle.Right-2,this.ClientRectangle.Y+1);


				e.DrawLine(pnsBorder,this.ClientRectangle.X+1,this.ClientRectangle.Y,this.ClientRectangle.Right-2,this.ClientRectangle.Y);
				e.DrawLine(pnsBorder,this.ClientRectangle.X,this.ClientRectangle.Y+1,this.ClientRectangle.X,this.ClientRectangle.Bottom-2);
				e.DrawLine(pnsBorder,this.ClientRectangle.X+1,this.ClientRectangle.Bottom-1,this.ClientRectangle.Right-2,this.ClientRectangle.Bottom-1);
				e.DrawLine(pnsBorder,this.ClientRectangle.Right-1,this.ClientRectangle.Y+1,this.ClientRectangle.Right-1,this.ClientRectangle.Bottom-2);

				//////////////////////////////////////////////////////////////////end Border
				

				OnDrawTextAndImage(e);
				myLinearGradientBrush.Dispose();
				myLinearGradientBrush1.Dispose();
				brsBorder.Dispose();
				brsDot.Dispose();
				pnsBorder.Dispose();
				pnsDot.Dispose();
				pnsInBorder.Dispose();
				
			}
			
			
		}
		private void OnDrawTextAndImage(Graphics g)
		{
			SolidBrush brushText;
		
			if (Enabled)
				brushText = new SolidBrush(ForeColor);
			else
				brushText = new SolidBrush(ControlPaint.DisabledForeColor);

			StringFormat sf = ControlPaint.GetStringFormat(this.TextAlign);
			sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
			
			g.TextRenderingHint=System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
			if (this.Image != null)
			{
				Rectangle rc=new Rectangle();
				Point ImagePoint= new Point(6, 4);
				switch(this.ImageAlign)
				{
					case ContentAlignment.MiddleRight:
					{
						rc.Width=this.ClientRectangle.Width-this.Image.Width-8;
						rc.Height=this.ClientRectangle.Height;
						rc.X=0;
						rc.Y=0;
						ImagePoint.X = rc.Width;
						ImagePoint.Y = this.ClientRectangle.Height/2-Image.Height/2;
						break;
					}
					case ContentAlignment.TopCenter:
					{
						ImagePoint.Y = 2;
						ImagePoint.X = (this.ClientRectangle.Width-this.Image.Width)/2;
						rc.Width=this.ClientRectangle.Width;
						rc.Height=this.ClientRectangle.Height-this.Image.Height-4;
						rc.X=this.ClientRectangle.X;
						rc.Y=this.Image.Height;

						break;
					}
					case ContentAlignment.MiddleCenter:
					{ // no text in this alignment
						ImagePoint.X = (this.ClientRectangle.Width-this.Image.Width)/2;
						ImagePoint.Y = (this.ClientRectangle.Height-this.Image.Height)/2;
						rc.Width=0;
						rc.Height=0;
						rc.X=this.ClientRectangle.Width;
						rc.Y=this.ClientRectangle.Height;
						break;
					}
					default:
					{
						ImagePoint.X = 6;
						ImagePoint.Y = this.ClientRectangle.Height/2-Image.Height/2;
						rc.Width=this.ClientRectangle.Width-this.Image.Width;
						rc.Height=this.ClientRectangle.Height;
						rc.X=this.Image.Width;
						rc.Y=0;
						break;
					}
				}
				ImagePoint.X += locPoint.X;
				ImagePoint.Y += locPoint.Y;
				if (this.Enabled) 
					g.DrawImage(this.Image, ImagePoint.X,ImagePoint.Y); 
				else 
					System.Windows.Forms.ControlPaint.DrawImageDisabled(g, this.Image, ImagePoint.X,ImagePoint.Y, this.BackColor);
				if(ContentAlignment.MiddleCenter !=this.ImageAlign)
				{
					g.DrawString(this.Text,this.Font,brushText,rc,sf);

				}
			}
			else
				g.DrawString(this.Text,this.Font,brushText,this.ClientRectangle,sf);
				
			
			brushText.Dispose();

			sf.Dispose();
		}
		#endregion


		private void SpecialButton_MouseLeave(object sender, System.EventArgs e)
		{
			timer1.Enabled=true;
			timer2.Enabled=false;
			timer3.Enabled=false;	
		}
 
		private void SpecialButton_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			timer3.Enabled=true;
			timer2.Enabled=false;
			timer1.Enabled=false;	
		}

		private void SpecialButton_Leave(object sender, System.EventArgs e)
		{
			timer1.Enabled=true;
			timer2.Enabled=false;
			timer3.Enabled=false;
			
		}
		private void SpecialButton_MouseEnter(object sender, System.EventArgs e)
		{
			timer2.Enabled=true;
			timer1.Enabled=false;
			timer3.Enabled=false;
		}

		private void SpecialButton_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			timer1.Enabled=false;
			timer2.Enabled=true;
			timer3.Enabled=false;
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.DrawControl(this.CreateGraphics());
			sp=false;
			timer1.Enabled=false;
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			this.onDrawControl(this.CreateGraphics());
			sp=true;
			timer2.Enabled=false;
		}
		
		private void timer3_Tick(object sender, System.EventArgs e)
		{
			this.pressDrawControl(this.CreateGraphics());
			sp=true;
			timer3.Enabled=false;
		}

		
				
		public bool DoubleBufferingEnabled()
		{
			return this.GetStyle(ControlStyles.DoubleBuffer | 
				ControlStyles.UserPaint | 
				ControlStyles.AllPaintingInWmPaint);

		}

		private void SpecialButton_ParentChanged(object sender, System.EventArgs e)
		{
			this.DrawControl(this.CreateGraphics());
		}

		

	}
}
