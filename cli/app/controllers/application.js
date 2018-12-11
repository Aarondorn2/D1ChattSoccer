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
      this.toggle('showMenu');
    },

    logIn(provider) {
      this.session.open(provider)
        .then(() => {          
          //this.transitionToRoute('secure.dashboard');
        })
        .catch(() => this.notify.error('Unable to log in. Please try again later.'))
        .finally(() => this.set('showLoginModal', false));
    },

    logOut() {
      this.session.close();
    }
  }
});
