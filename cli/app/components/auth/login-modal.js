import $ from 'jquery';
import Component from '@ember/component';
import { inject as service } from '@ember/service';
import { computed }  from '@ember/object';


export default Component.extend({
  router: service(),
  session: service(),

  email: "",
  resetEmail: "",
  password: "",
  isSendSuccess: false,
  isPasswordResetUnknownError: false,
  isPasswordResetBadEmailError: false,
  isPasswordResetSuccess: false,
  errorMessage: "",

  isPasswordResetFirstAttempt: computed('isPasswordResetUnknownError','isPasswordResetBadEmailError', 'isPasswordResetSuccess', function() {
    return !this.get('isPasswordResetUnknownError')
      && !this.get('isPasswordResetBadEmailError')
      && !this.get('isPasswordResetSuccess'); //if theres another message to display, this is false
  }),

  actions: {
    signIn: function(provider) {
      $('#login-button').attr("disabled", true);

      let providerData = {provider: provider};

      if(provider === "password") {
        if(this.get('email') && this.get('password')) {
          providerData.email = this.get('email');
          providerData.password = this.get('password');
        } else {
          this.set('errorMessage', 'Please provide an email and password.');
          $('#login-button').attr("disabled", false);
          return;
        }
      } else if (provider === "google") {
        //set scopes
        providerData.settings = {
          scope: 'https://www.googleapis.com/auth/userinfo.email'
        };
      } else if (provider === "facebook") {
        //set scopes
        providerData.settings = {
          scope: 'email'
        };
      }

      this.get('session').open('firebase', providerData).then(
        function() { //success
          $('#login-modal').modal('hide');
          this.get('router').transitionTo('secure.dashboard');
        }.bind(this),
        function(error) { //fail
          switch (error.code) {
            case "auth/invalid-email":
            case "auth/user-not-found":
            case "auth/wrong-password":
              this.set('errorMessage', 'The email/password you provided are invalid.  Please try again.'); //TODO use alert-message instead
              break;
            default:
              this.set('errorMessage', 'An unknown error has occured.  Please try again later.');
              break;
          }

          $('#login-button').attr("disabled", false);
        }.bind(this)
      );

    },

    resetPassword: function() { //TODO captcha ,email validation
      let resetEmail = this.get('resetEmail');

      if(resetEmail) {
        //spin and debounce
        $('#reset-spinner').toggleClass('show').toggleClass('hide');
        $('#reset-button').attr("disabled", true);

        //reset flags
        this.set('isPasswordResetBadEmailError', false);
        this.set('isPasswordResetUnknownError', false);


        let auth = this.get('firebaseApp').auth();
        auth.sendPasswordResetEmail(resetEmail)
          .then(function() {
            this.set('isPasswordResetSuccess', true);
            this.set('resetEmail', '');
            $('#reset-button').attr("disabled", false);

          }.bind(this))
          .catch(function(error) {
            switch (error.code) {
              case "auth/invalid-email":
              case "auth/user-not-found":
                this.set('isPasswordResetBadEmailError', true);
                break;
              default:
                this.set('isPasswordResetUnknownError', true);
                break;
              }
              
            $('#reset-button').attr("disabled", false); //enable button so they can re-try
          }.bind(this));
      } else {
        this.set('isPasswordResetBadEmailError', true);
      }
      //remove spinner
      $('#reset-spinner').toggleClass('show').toggleClass('hide');
    },

    showEmail: function() {
      $('#login-email').toggleClass('show').toggleClass('hide');
    },

    showResetPassword: function() {
      $('#login-email').toggleClass('show').toggleClass('hide');
      $('#reset-password').toggleClass('show').toggleClass('hide');
    },

    submitLogin: function() {
      $('#login-button').click();
    },

    routeToRegister: function() {
      this.get('router').transitionTo('auth.register');
    }
  }
});