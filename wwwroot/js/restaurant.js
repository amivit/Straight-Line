var xKoordinat;
var id;
var optaget;
var elem = document.getElementById('myCanvas'),
    elemLeft = elem.offsetLeft,
    elemTop = elem.offsetTop,
    context = elem.getContext('2d'),
    elements = [];

var jsonObjects;
UpdateJSON();
function UpdateJSON() {
    var jsonURL = '/api/Restaurant';
     $.getJSON(jsonURL, function (data) {
         jsonObjects = data;
         DrawElements();
     });
}
function DrawElements() {
    // Render elements.
    elem.height = 120 * jsonObjects.length;
    toplocation = 20;
    for (i = 0; i < jsonObjects.length; i++) {
        elements.push({
            id: i,
            colour: 'grey',
            width: 100,
            height: 100,
            top: toplocation,
            left: 20,
            clicked: false,
            optaget: false
        });
        toplocation = toplocation + 120;
    }
    elements.forEach(function (element) {
        context.fillStyle = element.colour;
        context.fillRect(element.left, element.top, element.width, element.height);
    });
}
// Add event listener for `click` events.
elem.addEventListener('click', function (event) {
    var x = event.pageX - elemLeft,
        y = event.pageY - elemTop;

    // Collision detection between clicked offset and element.
    elements.forEach(function (element) {
        if (y > element.top && y < element.top + element.height
            && x > element.left && x < element.left + element.width) {
            if (element.clicked === true) {
                element.colour = 'grey';
                context.fillStyle = element.colour;
                context.fillRect(element.left, element.top, element.width, element.height);
                element.clicked = false;
            } else {
                context.fillStyle = 'green';
                context.fillRect(element.left, element.top, element.width, element.height);
                element.clicked = true;
            }
        }
    });
}, false);
