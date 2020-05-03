// This javascript file contains the logic for mapbox handling of animal location

const TOKEN = "pk.eyJ1Ijoic2hhaHJvb3FwYXRoYW4iLCJhIjoiY2sweHQ2cGI2MDkzMDNibzN1aDd2b3NxZCJ9.mkmi_lQe7LYTmNSsV8V8bw";
var locations = [];
var selectedAnimal = "All";
console.log(selectedAnimal);

var currentMarkers = [];
// The first step is obtain all the latitude and longitude from the HTML
// The below is a simple jQuery selector

$('#animalFilter a').on('click', function () {
    selectedAnimal = $(this).html();
    refreshMap();
});


$(".coordinates").each(function () {

    var longitude = $(".longitude", this).text().trim();
    var latitude = $(".latitude", this).text().trim();
    var description = $(".description", this).text().trim();
    var animalClass = $(".animal-class", this).text().trim();
    // Create a point data structure to hold the values.
    var point = {
        "latitude": latitude,
        "longitude": longitude,
        "description": description,
        "animalClass": animalClass
    };
    // Push them all into an array.
    locations.push(point);
});

/*
var data = [];
for (i = 0; i < locations.length; i++) {
    var feature = {
        "type": "Feature",
        "properties": {
            "description": locations[i].description,
            "icon": "theatre-15"
        },
        "geometry": {
            "type": "Point",
            "coordinates": [locations[i].longitude, locations[i].latitude]
        }
    };
    console.log(locations[i])
    data.push(feature)
}
*/

mapboxgl.accessToken = TOKEN;

var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v10?optimize=true',
    zoom: 7,
    center: [locations[0].longitude, locations[0].latitude]
});

map.on('load', function () {
    /* console.log(data);
    // Add a layer showing the places.
    map.addLayer({
        "id": "places",
        "type": "symbol",
        "source": {
            "type": "geojson",
            "data": {
                "type": "FeatureCollection",
                "features": data
            }
        },
        "layout": {
            "icon-image": "{icon}",
            "icon-allow-overlap": true
        }
    }); */
    map.addControl(new MapboxGeocoder({
        accessToken: mapboxgl.accessToken
    }));;
    map.addControl(new mapboxgl.NavigationControl());

    // Add geolocate control to the map.
    map.addControl(new mapboxgl.GeolocateControl({
        positionOptions: {
            enableHighAccuracy: true
        },
        trackUserLocation: true
    }));


    for (i = 0; i < locations.length; i++) {
        if (selectedAnimal == "All" || locations[i].description == selectedAnimal) {
            var animalLocation = [locations[i].longitude, locations[i].latitude];

            // create the popup
            var popup = new mapboxgl.Popup({ offset: 25 }).setHTML(
                '<b>Animal:</b> ' + locations[i].description + '</br>' +
                '<b>Type:</b> ' + locations[i].animalClass
            );


            // create DOM element for the marker for all animals
            if (locations[i].description == 'Koala') {
                var el = document.createElement('div');
                el.id = 'marker-koala';
            }
            else if (locations[i].description == 'Quokka') {
                var el = document.createElement('div');
                el.id = 'marker-quokka';
            }
            else if (locations[i].description == 'Kangaroo') {
                var el = document.createElement('div');
                el.id = 'marker-kangaroo';
            }
            else if (locations[i].description == 'Penguin') {
                var el = document.createElement('div');
                el.id = 'marker-penguin';
            }
            else if (locations[i].description == 'Emu') {
                var el = document.createElement('div');
                el.id = 'marker-emu';
            }



            // create the marker
            var marker = new mapboxgl.Marker(el)
                .setLngLat(animalLocation)
                .setPopup(popup) // sets a popup on this marker
                .addTo(map);

            currentMarkers.push(marker);
        }


    }



});

function clearMarkers() {
    console.log(currentMarkers.length)
    currentMarkers.forEach((marker) => marker.remove());
    currentMarkers = [];
}


function refreshMap() {

    clearMarkers();

    for (i = 0; i < locations.length; i++) {
        if (selectedAnimal == "All" || locations[i].description == selectedAnimal) {
            var animalLocation = [locations[i].longitude, locations[i].latitude];

            // create the popup
            var popup = new mapboxgl.Popup({ offset: 25 }).setHTML(
                '<b>Animal:</b> ' + locations[i].description + '</br>' +
                '<b>Type:</b> ' + locations[i].animalClass
            );



            // create DOM element for the marker for all animals
            if (locations[i].description == 'Koala') {
                var el = document.createElement('div');
                el.id = 'marker-koala';
            }
            else if (locations[i].description == 'Quokka') {
                var el = document.createElement('div');
                el.id = 'marker-quokka';
            }
            else if (locations[i].description == 'Kangaroo') {
                var el = document.createElement('div');
                el.id = 'marker-kangaroo';
            }
            else if (locations[i].description == 'Penguin') {
                var el = document.createElement('div');
                el.id = 'marker-penguin';
            }
            else if (locations[i].description == 'Emu') {
                var el = document.createElement('div');
                el.id = 'marker-emu';
            }

            // create the marker
            var marker = new mapboxgl.Marker(el)
                .setLngLat(animalLocation)
                .setPopup(popup) // sets a popup on this marker
                .addTo(map);

            currentMarkers.push(marker);
        }
    }

}

/*
    // When a click event occurs on a feature in the places layer, open a popup at the
    // location of the feature, with description HTML from its properties.
    map.on('click', 'places', function (e) {
        var coordinates = e.features[0].geometry.coordinates.slice();
        var description = e.features[0].properties.description;
        // Ensure that if the map is zoomed out such that multiple
        // copies of the feature are visible, the popup appears
        // over the copy being pointed to.
        while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
            coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        }
        new mapboxgl.Popup()
            .setLngLat(coordinates)
            .setHTML(description)
            .addTo(map);
    });

    // Change the cursor to a pointer when the mouse is over the places layer.
    map.on('mouseenter', 'places', function () {
        map.getCanvas().style.cursor = 'pointer';
    });
    // Change it back to a pointer when it leaves.
    map.on('mouseleave', 'places', function () {
        map.getCanvas().style.cursor = '';
    });

    var layerList = document.getElementById('menu');
    var inputs = layerList.getElementsByTagName('input');

    function switchLayer(layer) {
        map.remove()
        var layerId = layer.target.id;

        map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/' + layerId,
            zoom: 11,
            center: [locations[0].longitude, locations[0].latitude]
        });

        map.on('load', function () {
            console.log("THIS IS WORKING")
            // Add a layer showing the places.
            map.addLayer({
                "id": "places",
                "type": "symbol",
                "source": {
                    "type": "geojson",
                    "data": {
                        "type": "FeatureCollection",
                        "features": data
                    }
                },
                "layout": {
                    "icon-image": "{icon}",
                    "icon-allow-overlap": true
                }
            });

            map.addControl(new MapboxGeocoder({
                accessToken: mapboxgl.accessToken
            }));;
            map.addControl(new mapboxgl.NavigationControl());

            // Add geolocate control to the map.
            map.addControl(new mapboxgl.GeolocateControl({
                positionOptions: {
                    enableHighAccuracy: true
                },
                trackUserLocation: true
            }));
        });
        //map.setStyle('mapbox://styles/mapbox/' + layerId);
        //reloadMap();

    }

    for (var i = 0; i < inputs.length; i++) {
        inputs[i].onclick = switchLayer;
    }
    */