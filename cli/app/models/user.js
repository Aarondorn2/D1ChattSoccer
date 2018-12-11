import attr from 'ember-data/attr';
import Model from 'ember-data/model';

export default Model.extend({
  firstName: attr('string'),
  lastName: attr('string'),
  email: attr('string'),
  dob: attr('date'),
  shirtSize: attr('string'),
  gender: attr('string'),
  isKeeper: attr('boolean'),
  isOffense: attr('boolean'),
  isDefense: attr('boolean'),
  phone: attr('string'),
  emergencyContact: attr('string'),
  emergencyContactPhone: attr('string'),
  userType: attr('string')
});
