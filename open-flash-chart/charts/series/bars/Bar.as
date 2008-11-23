package charts.series.bars {
	
	import flash.display.Sprite;
	import flash.geom.Point;
	import charts.series.bars.PointBarBase;
	
	public class Bar extends PointBarBase {
	
		public function Bar( index:Number, style:Object, group:Number ) {
			
			super(index, style, style.colour, style.tip, style.alpha, group);
		}
		
		public override function resize( sc:ScreenCoordsBase, axis:Number ):void {
			
			var h:Object = this.resize_helper( sc as ScreenCoords, axis );
			
			this.graphics.clear();
			this.graphics.beginFill( this.colour, 1.0 );
			this.graphics.moveTo( 0, 0 );
			this.graphics.lineTo( h.width, 0 );
			this.graphics.lineTo( h.width, h.height );
			this.graphics.lineTo( 0, h.height );
			this.graphics.lineTo( 0, 0 );
			this.graphics.endFill();
		}
		
	}
}