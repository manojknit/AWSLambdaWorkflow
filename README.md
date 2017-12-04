
# CloudJibe - iPromo
####                                                                                                     By CloudJibe
## Introduction 
“iPromo” - An enterprise level cloud base promotion/deal approval system. This application provides secure, highly available, reliable and scalable platform for promotions approvals. This is enterprise level application to support HTTPS and single sign-on.   

## Table of content
* Agenda
* Features
* Technologies Used
* Architecture diagrams
* Application Screenshots
* How to Run
* AWS Infrastructure Detail
* Licence
* Refrence

## Agenda
This application demonstrates Azure Active Directory Single Sign-On Authentication, CRUD operations with AWS RDS MySQL, Approval flow with AWS State Machine, AWS Lex help chat, CICD with Docker and Cloud Formation, File download from AWS CloudFront with AWS SDK for .NET with .NET Core, ASP.NET Core MVC, JQuery, Bootstrap, Pomelo.EntityFrameworkCore.MySql.

## Features
1.	Name: CloudJibe – iPromo: Enterprise Promotion/deal approval system.
2.	Highly available, scalable, durable and globally accessible application.
3.	Secure SSO and role base authorization.
4.	Promotion submission capability by Regional sales Representative
5.	Promotion Approval by Pricing Team
6.	Option for Email Approval by Pricing Team
7.	Reporting
8.	Chat Bot for Help
    * End user service
    * Online conversation
    * Purchase Histories
    * New Request Positions
    * Streamlining workflow
9.	CloudWatch Alarm is set with SNS topic email notifications for Elastic Beanstalk network traffic crosses threshold traffic.
10.	Site is also configured for HTTPs. Secure login using HTTPs.
11.	Faster release cycle using AWS CICD with Docker

## Technologies Used
*	Using Azure and AWS cloud platforms
*	ASP.NET MVC Core 2 (latest open-source and cross-platform framework)
*	Micro services (AWS API Gateway and Rest APIs)
*	JQuery, JSON, Javascript – Client side scripting
*	HTML5
*	CSS3 - Styling
*	Bootstrap – to make responsive UI
*	Bower js Client side web package manager
*	NuGet - Package manager
*	Js and CSS Bundling and Minification
*	Pomelo.EntityFrameworkCore.MySql - ORM
*	AWS SDK for .NET Core – To communicate to AWS services. 
*	Azure AD Tenant – Enterprise user data for authentication
*	Azure AD Federation Authentication – For Single Sign On.
*	Elastic Beanstalk – Multi-AZ and auto scale deployment.
*	Continuous Integration and Continuous Delivery Pipeline in AWS (CICD) – GitHub, CodeBuild, Test, CodeDeploy, AWS CodeStar
*	Docker – used to build project and deploy
*	Cloud Formation
*	EC2 – Auto scale “64bit Windows Server 2016 v1.2.0 running IIS 10.0” EC2 instances are used.
*	ELB – used for load balancing
*	AutoScaling Group – Multi AZ deployment is set for auto scaling
*	AWS SAM(Serverless Application Model). Lambda:
    o Worker Lambda to initiate task in Step Function workflow. 
    o Post Workflow update lambda. Triggered as a part of Step Function.
*	AWS Step Functions State machine Workflow implementation for task orchestration 
*	API Gateway – Endpoint for email approval. Integrates to Step function.
*	Amazon Simple Email Service (SES) Useing to send emails for approvals 
*	Single AZ RDS Db converted to Multi AZ Select Instance -> Instance Action -> Modify -> Multi AZ deployment to Yes.
*	Parameter Store: Simple Systems Management - SSM 
*	KMS - Key to Encryption sensitive secrets 
*	IAM – Permissions/role/group
*	S3 for object storage
*	S3 Transfer Acceleration
*	CloudFront – caching for faster file download.
*	R53 – domain registration, URL configuration
*	CloudWatch – Monitoring, log and notification
*	Amazon Simple Notification Service (SNS)
*	GitHub – For configuration management
*	Cognito Federated Identities
*	Amazon Lex
*	Integration with Slack


## Architecture diagrams

<img src="/Images/CloudArchitecture.png">


<img src="/Images/StateMachineEmailApproval.png">


```
{
  "Comment": "Sales Promotion Approval Process!",
  "StartAt": "PMApprovalActivity",
  "States": {
    "PMApprovalActivity": {
      "Type": "Task",
      "Resource": "arn:aws:states:us-east-1:494875521123:activity:PMApprovalStep",
      "TimeoutSeconds": 3600,
      "Next": "PostPMApprovalActivity"
    },
    "PostPMApprovalActivity": {
      "Type": "Task",
      "Resource": "arn:aws:lambda:us-east-1:494875521123:function:UpdateDBonApproval",
      "End": true
    }
  }
}
```


<img src="/Images/VPC.png">


<img src="/Images/S3.png">


<img src="/Images/SequenceDiaASP.NetMVCCore.png">


<img src="/Images/WebAppArchitecture.png">


<img src="/Images/CICD.png">


<img src="/Images/Lex.png">


<img src="/Images/SlackIntegration.png">


## Application Screenshots
#### Sign in/Sign out Page: This application demonstrates Azure ADFS authentication.
<img src="/Images/sign_in.png">

#### Promotion Submission: Sales Rep can submit promotions for their customers.
<img src="/Images/promo_submission.png">

#### Worklist page: To see action items as per role and user
<img src="/Images/worklist.png">

#### Report: As per role report exposes data.
<img src="/Images/report.png">

#### Approval: Pricing manager can approve using web portal
<img src="/Images/approval.png">

#### Approval: Pricing manager can approve using email
<img src="/Images/email_approval.png">

#### State Machine: Workflow
<img src="/Images/strate_machine.png">

#### Chat Bot: For Help
<img src="/Images/slack.png">

## How to Run
* Visual Studio 2017
* Clone project and open in Visual studio 2017
* Enter your RDS MySQL database connection string in Startup.cs file line # 29.
* Place IAM.json file in root folder where Startup.cs is there. This file will have you AWS profile information. Sample is as follows.
```
[local-test-profile]
aws_access_key_id=XXXXXXXXXXXXXZX
aws_secret_access_key=YYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
region=us-west-1
```   
* Set up AWS infrastructure
* Setup Azure AD (Will cover in another article for How to)
* Now run your application
* This project is deployed on AWS Elastic Beanstalk on Multi AZ servers with load balancer and autoscaling.

## AWS infrastructure 
In AWS following 3 are the main technologies which are required to run App. However I used more to make secure, highly available, reliable and scalable application.
 1. Create S3 bucket with name as “homework2-manoj”. Enable versioning and transfer acceleration. Lifecycle can be set as architecture diagram to save cost. I also set permissions, user and group in IAM. 
<img src="images/S3-lifecycle.png"/>
 2. Setup AWS Lambda to send delete image notifications using AWS Simple Notification Service Topic. 
Code for Lambda in NodeJS:

```
var AWS = require('aws-sdk');
var sns = new AWS.SNS();
console.log('Loading function');

exports.handler = (event, context, callback) => {
 var srcBucket = event.Records[0].s3.bucket.name;   
    // Object key may have spaces or unicode non-ASCII characters.
    var srcKey    =
    decodeURIComponent(event.Records[0].s3.object.key.replace(/\+/g, " ")); 
    console.log(
                    'Successfully resized ' + srcBucket + '/' + srcKey 
                );
    
var params = {
  Message: 'CloudJibe portal iniciated filedeletion for file - ' + srcBucket + '/' + srcKey, /* required */
  MessageStructure: 'STRING_VALUE',
  Subject: 'File ('+srcKey+') deleted in S3 from CloudJibe portal',
  TopicArn: 'arn:aws:sns:us-west-1:476374:manojalb_health'
};
sns.publish(params, function(error, data) {
  if (error) console.log(error, err.stack); // an error occurred
  else     console.log(data);           // successful response
});

    //console.log('From SNS:', message);
    callback(null, 'Successfully resized ' + srcBucket + '/' + srcKey);
};
```
 3. Create RSD MySQL database. Run following script to create table.
```
CREATE TABLE FileUpdate (
id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
firstname VARCHAR(30) NOT NULL,
lastname VARCHAR(30) NOT NULL,
email VARCHAR(50),
upload_date datetime,
updated_date datetime,
file_name VARCHAR(50),
file_desc VARCHAR(100) 
)
```


## License
The iPromo – By CloudJibe is licensed under the terms of the GPL Open Source license and is available for free.
## Refrence
* University Name: http://www.sjsu.edu/ 
* Course: Cloud Technologies
* Professor [Sanjay Garje](https://www.linkedin.com/in/sanjaygarje/)
* ISA: [Divyankitha Urs](https://www.linkedin.com/in/divyankithaurs/)
* Student: [Manoj Kumar](https://www.linkedin.com/in/manojkumar19/)



