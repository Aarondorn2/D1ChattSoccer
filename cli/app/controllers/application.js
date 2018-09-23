import Controller from '@ember/controller';

export default Controller.extend({
  showMenu: false,

  actions: {
    toggleShowMenu: function(value = null) {
      this.set('showMenu', value != null ? value : !this.showMenu);
    }
  }
});
