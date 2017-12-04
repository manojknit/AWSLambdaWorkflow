'use strict';

const lexResponses = require('./lexResponses');

function buildValidationResult(isValid, violatedSlot, messageContent) {
  if (messageContent == null) {
    return {
      isValid,
      violatedSlot,
    };
  }
  return {
    isValid,
    violatedSlot,
    message: {contentType: 'PlainText', content: messageContent},
  };
}
function validateHelp(approved) {
  

  return buildValidationResult(true, null, null);
}

module.exports = function(intentRequest, callback) {
  var StatusCheck = intentRequest.currentIntent.slots.StatusCheck;
  var Approved = intentRequest.currentIntent.slots.Approved;
  var Confirmed = intentRequest.currentIntent.slots.Confirmed;
  console.log(StatusCheck + '' + Approved + '' + Confirmed);

  const source = intentRequest.invocationSource;
  if (source === 'DialogCodeHook') {
    const slots = intentRequest.currentIntent.slots;
    const validationResult = validateHelp(Approved);

    if (!validationResult.isValid) {
      slots[`${validationResult.violatedSlot}`] = null;
      callback(lexResponses.elicitSlot(intentRequest.sessionAttributes, intentRequest.currentIntent.name, slots, validationResult));
      return;
    }
    callback(lexResponses.delegate(intentRequest.sessionAttributes, intentRequest.currentIntent.slots));
    return;
  }

}
