import Component from '@ember/component';

export default Component.extend({
  email: "",
  resetEmail: "",
  password: "",
  isSendSuccess: false,
  errorMessage: "",

  actions: {
    showEmail() {
    }
  }
});