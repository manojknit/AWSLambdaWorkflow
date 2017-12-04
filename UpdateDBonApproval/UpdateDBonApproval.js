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
                host: process.env.RDS_HOSTNAME, // RDS endpoint
                user: process.env.RDS_USERNAME, // MySQL username
                password: process.env.RDS_PASSWORD, // MySQL password
                database: process.env.RDS_DB
            });
            conn.connect();
            
            console.log("connecting...");

            var qrrApprove = 'UPDATE Quote SET QuoteStatusLevelID = 2, QuoteStatusResultID = 14 WHERE QuoteID = '+input.quoteid;
            console.log("Query = " +qrrApprove);
            conn.query(qrrApprove, function(err, info) {
                console.log("Updated approved status: " + info.msg + " /err: " + err);
                conn.end();
            });
            console.log("Updated values in to database");
            //context.done(null, input.quoteid);
    }
    else
    {
        console.log('updating in RDS for reject');
        var connR = mysql.createConnection({
                host: process.env.RDS_HOSTNAME, // RDS endpoint
                user: process.env.RDS_USERNAME, // MySQL username
                password: process.env.RDS_PASSWORD, // MySQL password
                database: process.env.RDS_DB
            });
            connR.connect();
            console.log("connecting...");
            var qrrReject = 'UPDATE Quote SET QuoteStatusLevelID = 2, QuoteStatusResultID = 3 WHERE QuoteID = '+input.quoteid;
            console.log("Query = " +qrrReject);
            connR.query(qrrReject, function(err, info) {
                console.log("Updated reject status: " + info.msg + " /err: " + err);
                connR.end();
            });
            console.log("Updated values in to database"); 
            //context.done(null, input.quoteid);
    }
    //context.callbackWaitsForEmptyEventLoop = false;
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