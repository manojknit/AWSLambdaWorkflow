'use strict';
console.log('Loading function');
const aws = require('aws-sdk');
const stepfunctions = new aws.StepFunctions();
const ses = new aws.SES();
var mysql = require('mysql');
exports.handler = (event, context, callback) => {
    console.log('Event Starting Event string=' + JSON.stringify(event));
    //console.log('event='+JSON.stringify(event, null, 2));
    var input = JSON.parse(JSON.stringify(event).trim());
    console.log('quoteid = ' + input);
    if(input.action.toString() === 'approve')
    {
        console.log('updating in RDS for approve');
        var conn = mysql.createConnection({
                host: 'mysqldbinstance.cznkksrdyegb.us-east-1.rds.amazonaws.com', // RDS endpoint
                user: 'sqluser', // MySQL username
                password: 'Monday1$', // MySQL password
                database: 'mysqldb'
            });
            conn.connect();
            console.log("connecting...");
            conn.query('UPDATE Quote SET QuoteStatusResultID = 4 WHERE QuoteID = '+input.quoteid, function(err, info) {
                console.log("Updated approved status: " + info.msg + " /err: " + err);
                conn.end();
            });
            console.log("Updated values in to database");
            //context.done(null, input.quoteid);
    }
    else
    {
        console.log('updating in RDS for reject');
        var conn = mysql.createConnection({
                host: 'mysqldbinstance.cznkksrdyegb.us-east-1.rds.amazonaws.com', // RDS endpoint
                user: 'sqluser', // MySQL username
                password: 'Monday1$', // MySQL password
                database: 'mysqldb'
            });
            conn.connect();
            console.log("connecting...");
            conn.query('UPDATE Quote SET QuoteStatusResultID = 5 WHERE QuoteID = '+input.quoteid, function(err, info) {
                console.log("Updated reject status: " + info.msg + " /err: " + err);
                conn.end();
            });
            console.log("Updated values in to database"); 
            //context.done(null, input.quoteid);
    }
    
     console.log('output =', input);
    console.log('quoteid =', input.quoteid);
    console.log('taskToken =', event.taskToken);
    console.log('action =', input.action);
    console.log('functionName =', context.functionName);
    console.log('AWSrequestID =', context.awsRequestId);
    console.log('logGroupName =', context.logGroupName);
    console.log('logStreamName =', context.logStreamName);
    console.log('clientContext =', context.clientContext);
    
    console.log('activityArn'+context+'output= '+input);
    callback(null, "Promo# "+ input.quoteid+ " is approved");
};