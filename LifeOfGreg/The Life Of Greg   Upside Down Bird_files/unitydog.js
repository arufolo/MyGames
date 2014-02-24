var g_NumUnityDogs = 0;

var unityDog =
{
	Setup : function( element )
	{
		var webURL		= element.attr( "src" );
		var	defWidth	= element.attr( "width" );
		var defHeight	= element.attr( "height" );
	
		var unityelement = jQuery( "<div class=\"unitydog standard\"></div>" );
		
		// Add the controls
		var controls = jQuery( '<div class="controls"></div>' );
		
			var ctrl = jQuery( '<a class="make_fullscreen" ><img src="'+unitydogsettings.fullscreen+'"></a>' );
				ctrl.click( function(){ unityelement.addClass( 'fullscreen' ); unityelement.removeClass( 'standard' ); jQuery( 'BODY' ).addClass( 'unitydog_fullscreen' ); } );
			controls.append( ctrl );
		
			var ctrl = jQuery( '<a class="make_normal" ><img src="'+unitydogsettings.restore+'"></a>' );
				ctrl.click( function(){ unityelement.removeClass( 'fullscreen' ); unityelement.addClass( 'standard' ); jQuery( 'BODY' ).removeClass( 'unitydog_fullscreen' ); } );
			controls.append( ctrl );
			
		var playbutton = jQuery( '<div class="playbutton">&nbsp;</div>' );
		playbutton.click( function(){ unityDog.Play( unityelement, webURL ); } );
		
		unityelement.prepend( playbutton );
		unityelement.append( controls );
		
		element.replaceWith( unityelement );
	},
	
	Play : function( unityelement, webURL )
	{	
		var player = new UnityObject2( { width: "100%", height: "100%" } );
		
		// Stop all other instances
		unityDog.StopAll();
		
		// hide our play button
		unityelement.find( '.playbutton' ).hide();

		player.observeProgress( function ( progress ) 
		{
			switch( progress.pluginStatus ) 
			{
				                case "broken":

                    var missing_content = "";

                    missing_content += "<div align='center'> \n";

                    missing_content += "  Your Unity Web Player is broken,";

                    missing_content += "  please use the link below to reinstall it, and then restart your browser:<br /><br />\n";

                    missing_content += '<div class="broken">';

                    missing_content += '<a href="http://unity3d.com/webplayer/" title="Unity Web Player. Install now! Restart your browser after install." target="_blank">';

                    missing_content += '<img alt="Unity Web Player. Install now! Restart your browser after install." src="http://webplayer.unity3d.com/installation/getunityrestart.png" width="193" height="63" />';

                    missing_content += '</a>';

                    missing_content += '</div>';

                    missing_content += "</div> \n";

                    jQuery('.unitydog').css("background-color", "white").css("height", "130px").html(missing_content);

                    return;

                    break;

                case "missing":

                    var missing_content = "";

                    missing_content += "<div align='center'> \n";

                    missing_content += "  This content requires the Unity Web Player,";

                    missing_content += "  please use the link below to install the player, and then refresh this page:<br /><br />\n";

                    missing_content += '<div class="missing">';

                    missing_content += '<a href="http://unity3d.com/webplayer/" title="Unity Web Player. Install now!" target="_blank">';

                    missing_content += '<img alt="Unity Web Player. Install now!" src="http://webplayer.unity3d.com/installation/getunity.png" width="193" height="63" />';

                    missing_content += '</a>';

                    missing_content += '</div>';

                    missing_content += "</div> \n";

                    jQuery('.unitydog').css("background-color", "white").css("height", "130px").html(missing_content);

                    return;

                    break;
				case "installed":
					break;
				case "first":
					break;
			}

		});
		
		var plyelement = jQuery( '<div class="player"></div>' );
		unityelement.prepend( plyelement );

		player.initPlugin( plyelement[0], webURL );
	},
	
	StopAll : function()
	{
		jQuery( "DIV.unitydog .player" ).remove();
		jQuery( "DIV.unitydog .playbutton" ).show();
	}
}

jQuery(function()
{
	jQuery( 'unitydog' ).each( function( idx, element )
	{
		unityDog.Setup( jQuery( element ) );
	})
});