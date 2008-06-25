﻿package ChartObjects {
	import ChartObjects.Elements.Element;
	
	import flash.display.Sprite;
	import flash.display.BlendMode;
	
	public class BaseLine extends Base
	{
		// JSON style:
		protected var style:Object;
		
		
		public function BaseLine() {}
		
		// Draw lines...
		public override function resize( sc:ScreenCoords ): void {
			this.x = this.y = 0;

			this.graphics.clear();
			this.graphics.lineStyle( this.style.width, this.style.colour );
			
			var first:Boolean = true;
			
			for ( var i:Number = 0; i < this.numChildren; i++ ) {
				
				var tmp:Sprite = this.getChildAt(i) as Sprite;
				
				//
				// filter out the line masks
				//
				if( tmp is Element )
				{
					var e:Element = tmp as Element;
					
					tr.ace("!!!");
					tr.ace(e.screen_x);
					
					// tell the point where it is on the screen
					// we will use this info to place the tooltip
					e.resize( sc, 0 );
					if( first )
					{
						this.graphics.moveTo(e.screen_x,e.screen_y);
						first = false;
					}
					else
						this.graphics.lineTo(e.screen_x, e.screen_y);
				}
			}
		}
		
		public override function get_colour(): Number {
			return this.style.colour;
		}
		
		//
		// TODO this is so wrong. We need to query all the Elements
		//      for thier X value
		//
		public override function get_max_x_value():Number {
			
			var c:Number = 0;
			//
			// count the non-mask items:
			//
			for ( var i:Number = 0; i < this.numChildren; i++ )
				if( this.getChildAt(i) is Element )
					c++;
	
			return c;
		}
	}
}