'use strict';

const iPromoNext = require('./iPromoNext');

module.exports = function(intentRequest, callback) {
  console.log(`dispatch userId=${intentRequest.userId}, intentName=${intentRequest.currentIntent.name}`);
  const intentName = intentRequest.currentIntent.name;

  if(intentName === 'Help') {
    console.log(intentName + ' was called');
    return iPromoNext(intentRequest, callback);
  }

  throw new Error(`Intent with name ${intentName} not supported`);
}
