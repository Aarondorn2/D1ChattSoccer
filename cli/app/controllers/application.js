import Controller from '@ember/controller';
import { inject as service } from '@ember/service';
import { UserType } from '../utils/enum';

export default Controller.extend({
  notify: service(),

  showMenu: false,
  showLoginModal: false,
  UserType,

  actions: {
    toggleShowMenu() {
      this.toggleProperty('showMenu');
    },

    logIn(provider, email, pass) {
      let options = email && pass 
        ? { email, pass }
        : null;

      this.session.open(provider, options)
        .then(() => {          
          //this.transitionToRoute('secure.register');
        })
        .catch(() => this.notify.error('Unable to log in. Please try again later.'))
        .finally(() => this.set('showLoginModal', false));
    },

    logOut() {
      this.session.close();
    }
  }
});
