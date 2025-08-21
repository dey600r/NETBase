// var loadScript = (url: string) => {
// 	var script = document.createElement('script');
// 	script.type = 'text/javascript';
// 	script.src = url;

// 	document.getElementsByTagName('head')[0].appendChild(script);
// }

// loadScript('http://localhost:4201/remoteEntry.js');

import('./bootstrap')
	.catch(err => console.error(err));
