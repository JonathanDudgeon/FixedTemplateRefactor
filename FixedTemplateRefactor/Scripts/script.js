$(document).ready(function() {

   Cufon.now();

   $('#myRoundabout').roundabout({
                shape: 'square',
                minScale: 0.89, // tiny!
                maxScale: 1, // tiny!
                easing: 'easeOutExpo',
                clickToFocus: 'true',
                focusBearing: '0',
                duration: 800,
                reflect: true
            });

	var day=['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'],
	   month=['January','February','March','April','May','June','July','August','September','October','Novermber','December'];
	SetData2();
   function SetData2() {
       var now = new Date();
       $('time').html(day[now.getDay()] + ', ');
       $('time').append(' ' + month[now.getMonth()] + ' ');
       $('time').append(now.getDate() + ', ');
       $('time').append(now.getFullYear() + ' &nbsp; &nbsp; ');
       hour = now.getHours();
       minutes = now.getMinutes();
       if (minutes < 10) { minutes = '0' + minutes };
       $('time').append(hour + ':' + minutes);
   }
  	setInterval(SetData,60);

});
	