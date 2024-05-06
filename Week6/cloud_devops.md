# Cloud

## Different Levels of Services / Shared Responsibility Models
- Infrastructure as a Service - Virtual Machine Azure, EC2 AWS
- Platform as a Service - SQL Server
- Software as a Service - Gmail, Google Drive

## SLA (service level agreement)
- 99%, 99.9%, 99.99%, 99.999%
- Cloud Service Provider guarantees a certain amount of uptime

## Region / Availability Zone

## Scaling
- Vertical Scaling : quality
- Horizontal Scaling : quantity - vmss(virtual machine scale set), elastic beanstalk

## Resources
https://www.microsoft.com/en-us/trainingdays/azure
https://learn.microsoft.com/en-us/training/paths/microsoft-azure-fundamentals-describe-cloud-concepts/
https://learn.microsoft.com/en-us/certifications/exams/az-900/


# DevOps
- Philosophy 
- CI/CD pipeline
- CI:Continuous Integration
- CD: Continuous Delivery / Continous Deployment
- Pipelines to automate build/test/deploy

- Continuous Integration
  - Rapid integration of the code
  - Build/Test new code written before being merged into the main/stable branch
- Continuous Delivery/Deployment
  - take the built artifact and deploy it to an environtment (testing/QA, dev teams env, etc)

|---Build---|---Test---|---Release/Artifact---|---Deploy---|
|Continuous Integration|
|------------Continuous Delivery--------------|
|--------------------Continuous Deployment-----------------|


## Building Pipelines
1. You assemble an instruction sheet on how to build/test your app (yaml)
2. Ask a virtual machine to run that instruction for you
3. ???
4. Profit

## Tools for pipelines
- Jenkins
- Azure Devops pipeline
- AWS Codebuild/codepipeline
- Github Actions