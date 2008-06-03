<?php

// var_dump(debug_backtrace());

include_once 'JSON.php';
include_once 'json_format.php';

// ofc classes
include_once 'ofc_title.php';
include_once 'ofc_y_axis.php';
include_once 'ofc_x_axis.php';
include_once 'ofc_area_hollow.php';
include_once 'ofc_pie.php';
include_once 'ofc_bar.php';
include_once 'ofc_bar_glass.php';
include_once 'ofc_bar_stack.php';
include_once 'ofc_bar_3d.php';
include_once 'ofc_hbar.php';
include_once 'ofc_line_dot.php';
include_once 'ofc_x_legend.php';


class open_flash_chart
{
	function open_flash_chart()
	{
		$this->title = new title( "Many data lines" );
		$this->elements = array();
		$this->x_axis = new x_axis();
	}
	
	function set_title( $t )
	{
		$this->title = $t;
	}
	
	function set_x_axis( $x )
	{
		$this->x_axis = $x;	
	}
	
	function add_y_axis( $y )
	{
		$this->y_axis = $y;
	}
	
	function add_element( $e )
	{
		$this->elements[] = $e;
	}
	
	function set_x_legend( $x )
	{
		$this->x_legend = $x;
	}
	
	function toString()
	{
		$json = new Services_JSON();
		return $json->encode( $this );
	}
	
	function toPrettyString()
	{
		return json_format( $this->toString() );
	}
}



//
// there is no PHP end tag so we don't mess the headers up!
//