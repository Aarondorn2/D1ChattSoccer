import Controller from '@ember/controller';
import { inject as service } from '@ember/service';

export default Controller.extend({
  session: service(),
  
  showMenu: false,
  showLogin: false,

  actions: {
    toggleShowMenu: function(value = null) {
      this.set('showMenu', value != null ? value : !this.showMenu);
    },
    toggleShowLogin: function() {      
      this.toggleProperty('showLogin');
    }
  }
});
