import $ from 'jquery';
import EmberObject from '@ember/object';
import ENV from '../config/environment';
import RSVP from 'rsvp';

export default EmberObject.create({
  get(url) {
    return this.request('GET', url);
  },

  post(url, data) {
    return this.request('POST', url, data);
  },

  put(url, data) {
    return this.request('PUT', url, data);
  },

  delete(url, data) {
    return this.request('DELETE', url, data);
  },

  file(url, data) {
    return new RSVP.Promise((resolve, reject) => {
      $.ajax({
        type: 'POST',
        url: this.getUrl(url),
        data,
        contentType: false,
        processData: false
      }).then(resolve, jqXHR => {
        // Nested for Ember Error Route
        let error = { errors: [{
          status: `${jqXHR.status}`,
          title: jqXHR.statusText,
          detail: jqXHR.responseText,
          url
        }] };

        reject(error);
      });
    });
  },

  request(type, url, data) {
    return new RSVP.Promise((resolve, reject) => {
      $.ajax({
        type,
        url: this.getUrl(url),
        contentType: 'application/json',
        data: JSON.stringify(data)
      }).then(resolve, jqXHR => {
        // Nested for Ember Error Route
        let error = { errors: [{
          status: `${jqXHR.status}`,
          title: jqXHR.statusText,
          detail: JSON.stringify(data),
          message: jqXHR.responseText,
          url
        }] };

        reject(error);
      });
    });
  },

  getUrl(url) {
    return `${ENV.API.host}${ENV.API.namespace}/${url}`;
  }
});
