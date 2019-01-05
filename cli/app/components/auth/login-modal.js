import Component from '@ember/component';

export default Component.extend({
  email: "",
  resetEmail: "",
  password: "",
  showEmail: false,
  isSendSuccess: false,
  errorMessage: "",

  actions: {
    toggleEmail() {
      this.toggleProperty('showEmail');
    }
  }
});