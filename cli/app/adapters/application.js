import DS from 'ember-data';
import ENV from '../config/environment';
import { inject as service } from '@ember/service';
import { computed }  from '@ember/object';

export default DS.JSONAPIAdapter.extend({
  session: service(),

  host: ENV.API.host,
  namespace: ENV.API.namespace,
  headers: computed('session', function() {
    return {
      'Accept': 'application/vnd.app+json;version=1',
      'x-appid': 'd1soccer',
      'x-token': this.get('session.currentUser').Yd
    };
  })
});
