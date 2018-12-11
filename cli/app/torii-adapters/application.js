import ajax from '../utils/ajax';
import jwtDecode from 'ember-cli-jwt-decode';
import Object from '@ember/object';
import { Promise }  from 'rsvp';

export default Object.extend({
  open(auth) {
    let provider = auth.provider || 'facebook-connect';

    return ajax.post(`auth/${provider}`, auth)
      .then(jwt => {
        window.localStorage.setItem('jwt', jwt);
        return this.getUser(jwt);
      });
  },

  fetch() {
    return new Promise((resolve) => resolve(this.getUser(window.localStorage.getItem('jwt'))));
  },

  close() {
    return new Promise((resolve) => resolve(window.localStorage.removeItem('jwt')));
  },

  getUser(jwt) {
    let currentUser = jwt && jwtDecode(jwt);
    if (!currentUser) { throw 'Unable to get current user'; }

    if (currentUser.exp < (Date.now().valueOf() / 1000)) {
      this.close();
      throw 'User token has expired';
    }

    return { currentUser };
  }
});
