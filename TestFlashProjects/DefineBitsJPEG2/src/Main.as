package 
{
	import flash.display.Sprite;
	import flash.events.Event;
	
	/**
	 * ...
	 * @author ...
	 */
	public class Main extends Sprite 
	{
		
		public function Main():void 
		{
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private function init(e:Event = null):void 
		{
			removeEventListener(Event.ADDED_TO_STAGE, init);
			// entry point
		}
		
		[Embed('DefineBitsJPEG2.jpg')]
		private var image:Class;
		
	}
	
}