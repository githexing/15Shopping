<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppDown.aspx.cs" Inherits="Web.AppDown" %>

<html>
<head>
    <meta charset='utf-8' >
    <meta name='viewport' content="width=device-width, initial-scale=1, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no">
    <title>APP下载</title>

    <script type="text/javascript">
        var screenSize = document.documentElement.getBoundingClientRect();
        var fontSize = screenSize.width / 750 * 100;
        document.querySelector('html').style.fontSize = fontSize + 'px';
    </script>
	<link rel="stylesheet" type="text/css" href="/css/main.css"/>
</head>

<body>
	<div id="particles-js" class="side-menu-bg" style=" position: absolute; bottom: 0; right: 0; left: 0; top: 0;"></div>
    <div class="container">
        <div class="logo"></div>
        <div class="logo-title">释放币APP</div>
        <div class="intro">释放币将通过加密存储技术帮助您管理数字信息，让您的数据真正为自己所有，利用算力进行结算，您产生的价值越多，获得的回报越多… </div>

        <button id="ios" class="btn">IOS 下载</button>
        <button id="android" class="btn">Android 下载</button>
    </div>

    <div id='inWeixinPage' class="tip-mask" style="display: none;">
        <div class="wx-tips"></div>
    </div>
<script src="/js/particles.min.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
particlesJS("particles-js", {
  "particles": {
    "number": {
      "value": 60,
      "density": {
        "enable": true,
        "value_area": 800
      }
    },
    "color": {
      "value": "#ffffff"
    },
    "shape": {
      "type": "circle",
      "stroke": {
        "width": 0,
        "color": "#000000"
      },
      "polygon": {
        "nb_sides": 5
      },
    },
    "opacity": {
      "value": 0.5,
      "random": false,
      "anim": {
        "enable": false,
        "speed": 1,
        "opacity_min": 0.1,
        "sync": false
      }
    },
    "size": {
      "value": 3,
      "random": true,
      "anim": {
        "enable": false,
        "speed": 40,
        "size_min": 0.1,
        "sync": false
      }
    },
    "line_linked": {
      "enable": true,
      "distance": 150,
      "color": "#ffffff",
      "opacity": 0.4,
      "width": 1
    },
    "move": {
      "enable": true,
      "speed": 6,
      "direction": "none",
      "random": false,
      "straight": false,
      "out_mode": "out",
      "bounce": false,
      "attract": {
        "enable": false,
        "rotateX": 600,
        "rotateY": 1200
      }
    }
  },
  "interactivity": {
    "detect_on": "canvas",
    "events": {
      "onhover": {
        "enable": false,
        "mode": "grab"
      },
      "onclick": {
        "enable": false,
        "mode": "push"
      },
      "resize": true
    },
    "modes": {
      "grab": {
        "distance": 140,
        "line_linked": {
          "opacity": 1
        }
      },
      "bubble": {
        "distance": 100,
        "size": 40,
        "duration": 2,
        "opacity": 8,
        "speed": 3
      },
      "repulse": {
        "distance": 200,
        "duration": 0.4
      },
      "push": {
        "particles_nb": 4
      },
      "remove": {
        "particles_nb": 2
      }
    }
  },
  "retina_detect": true
});
</script>
</html>
