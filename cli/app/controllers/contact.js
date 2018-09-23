import Controller from '@ember/controller';

export default Controller.extend({
  lat: 35.03489461,
  lng: -85.14845471,
  zoom: 16,
  mapType: 'hybrid', // Accepts 'roadmap', 'satellite', 'hybrid', or 'terrain'
  showMapTypeControl: true,
  clickableIcons: true,
  draggable: true,
  disableDefaultUI: false,
  disableDoubleClickZoom: false,
  scrollwheel: true,
  showZoomControl: true,
  showScaleControl: true,
  markers: null,

  init() {
    this._super(...arguments);
    this.set('markers', [
      {
        id: 'D1 Chattanooga',
        lat: 35.03489461,
        lng: -85.14845471,
        infoWindow: {
          content: '<div style="text-align:center;"><h5>D1 Chattanooga</h5><p>7430 Commons Blvd, Chattanooga, TN 37421</p></div>',
          visible: false
        }
      }
    ]);
  }
});
