


if (window == top && !window.similarproducts && navigator.appVersion.toLowerCase().indexOf('msie 7') == -1)
{
    (function()
    {
        var nofish = false;
        var metaTags = document.getElementsByTagName('meta');
        var metaTag;
        var windowLocation = window.location.href.toLowerCase();

        for (var i=0, l=metaTags.length; i<l; i++)
        {
            metaTag = metaTags[i];

            if (metaTag.getAttribute('name') && metaTag.getAttribute('name').toLowerCase() == 'superfish' && metaTag.getAttribute('content') && metaTag.getAttribute('content').toLowerCase() == 'nofish')
            {
                nofish = true;
                break;
            }
        }

        if (nofish || !(windowLocation.indexOf('.google.') == -1  || (windowLocation.indexOf('www.google.') != -1 && windowLocation.indexOf('www.google.com/analytics/') == -1)))
        {
            return;
        }

        

        window.similarproducts = {};
similarproducts.b = {
    inj : function( d, url, js, cb)
{
	if (window.location.protocol.indexOf( "https" ) > -1 && url.indexOf( "localhost" ) == -1) {
        url = url.replace("http:","https:");
    }
    else {
        url = url.replace("https","http");
    }

    var h = d.getElementsByTagName('head')[0];
    var s = d.createElement( js ? "script" : 'link' );

    if( js ){
        s.type = "text/javascript";
        s.src = url;
    }else{
        s.rel = "stylesheet";
        s.href = url;
    }
    if(cb){
        s.onload = ( function( prm ){
            return function(){
                cb( prm );
            }
        })( url );
        // IE 
        s.onreadystatechange = ( function( prm ) {
            return function(){
                if (this.readyState == 'complete' || this.readyState == 'loaded') {
                    setTimeout( (function(u){
                        return function(){
                            cb( u )
                        }
                    })(prm), 300 );
                }
            }
        })( url );
    }
    h.appendChild(s);
    return s;
}
};




        var srcRegex = /\/sf_main\.|\/sf_conduit\.|\/sf_conduit_mam\.|\/sf_conduit_mam_app\.|\/sfw\./i; // Test for script tag src that may contain the app params query string
        var queryStringRegex = /CTID=(CT2680812|CT2652911|CT2659749|CT2695421|CT2666540)/i // Test for "specialsavings" patch
        var retryCounter = 1; // Used in the run() function as a fallback condition after 5 attempts
        var timeoutHandle;

        function extractQueryString()
        {
            var queryString = '';
            var scripts = document.getElementsByTagName('script');
            var scriptSrc;

            try
            {
                for (var i=0, l=scripts.length; i<l; i++)
                {
                    scriptSrc = scripts[i].src;

                    if (srcRegex.test(scriptSrc))
                    {
                        if (scriptSrc.indexOf('?') != -1)
                        {
                            var tempQueryString = scriptSrc.substring(scriptSrc.indexOf('?'));
                            queryString = fixQs(tempQueryString);
                        }

                        break;
                    }
                }
            }
            catch(ex)
            {
                queryString = '';
            }

            return queryString;
        }

        function fixQs(initialQS){
            var fixedQS = '?';
            initialQS.replace(
                new RegExp("([^?=&]+)(=([^&]*))?", "g"),
                function($0, $1, $2, $3)
                {

                    switch ($1)
                    {
                        case 'dlsource':
                            $3 = decodeURIComponent($3).trim();
                        break;
                    }

                    fixedQS = fixedQS + $1 + '=' + $3 + '&';
                }
            );
            return fixedQS.substring(0, fixedQS.length - 1);
        }

        function loadApp(queryString)
        {
            queryString += (queryString == '') ? '?' : '&';
            queryString += 'ver=13.1.1.45';

            if (queryStringRegex.test(queryString)) // Specialsavings patch
            {
                if (queryString.indexOf('dlsource=') > -1)
                {
                    queryString = queryString.replace(/dlsource=([^&]*)?/g, 'dlsource=specialsavings_tb');
                }
                else
                {
                    queryString += '&dlsource=specialsavings_tb';
                }
            }

            // Assign values to the global similarproducts object
            similarproducts.b.initialQS = queryString;
            similarproducts.b.inj(window.document, 'https://www.superfish.com/ws/sf_preloader.jsp' + queryString, 1);
        }

        function run()
        {
            var queryString = extractQueryString();

            timeoutHandle && clearTimeout(timeoutHandle);

            if (queryString || retryCounter >= 5)
            {
                eval("window.s"+"u"+"p"+"e"+"r"+"f"+"i"+"s"+"h"+"=similarproducts");
                loadApp(queryString);
            }
            else
            {
                retryCounter++;
                timeoutHandle = setTimeout(run, 50);
            }
        }

        /* --- Begin app loading cycle --- */
        run();
    })();
}