# Docker
Docker is a containerization platform that allows developers to package their application alongside with their dependencies in one convenient place/package. It allows software to be run independently of os/platform

## Docker Example
In Review folder

## If you are given an empty machine (not even an OS) with internet connection and were to run your API there...
## Now imagine, if you had a virtual machine on the cloud and wanted to run your application
1. Install the OS
2. Make sure it has git
3. Make sure it has SDK
4. Clone the repo
5. Restore dependencies/package references
6. Build dependencies/application -> artificts/executables
7. Run that executable

### So what if... we can package our app alongside with all our dependencies (not just the libraries, but things like runtime) and put a pretty button for someone to push?


## Containerization
Is a way to provide *uniform environment* to run our app regardless of whichever machine we end up in.

## Terms
- docker engine
    - is the daemon(software that sits in the background idly and wait for work) that actually runs all docker commands

- dockerfile
    - Is a file of instructions to docker engine in order to create a file system (or Image) that has everything you need to run your app (your app, your dependencies, your runtime, etc.)
    - in a dockerfile, we put stuff like which runtime to use, how to build our application, and what to do when someone runs the image

- dockerignore
    - gitignore file for dockerfile

- (Docker) Image
    - Is a **file system** that contains your application artifacts, your dependencies, runtime, reverse proxy, etc, whatever you need to run your application

- Tag
    - Tag is a way to differentiate between different versions of the same image. 
    We can use tag to discern between different builds (ie does this image have the latest changes?). Other times people use it to provide different versions to users (such .NET SDK docker image)

- Container
    - Virtualized OS/Software
    - Resources are dynamically allocated (in VM's resources are statically allocated)
    - It's smaller (in 100's of Mb's and maybe a few Gb's)

- Image Registry (Docker Hub)
    - Is a place to upload/download/share images. Docker hub is one of the biggest image registries for docker images, and this is like what github is to git.

- both containers and virtual machines achieve the same goal -> being able to run isolated uniform environments regardless of host machine


## Docker CLI Commands
- To run local images:
    -`docker run image-name`
    - `-d` "detached" runs the container in the background
    - `-p host:container` to map container port to host machine
    - `docker run -d -p 8080:8080 aschil/snake`
    - `-i` interactive for your interactive console applications
- To see all your local images:
    - `docker image ls`
- to remove your local image
    - `docker image rm image-name-or-image-id`
- the above two commands are the same for containers as well
    - `docker container ls`
    - `docker container rm container-id`
- when in doubt, `docker resource-name --help`
- To download image from docker hub
    - `docker pull image-name`
- To upload image to docker hub
    - `docker push image-name`
- To build our image from dockerfile
    - `docker build`
    - `docker build -t dockerhubusername/imagename:tag-name relative-path-to-folder-containing-dockerfile`
    - ex: `docker build -t sminseonong/pokestorage:latest .`
- To run image with env variables:
  - `docker run -it -p 8000:80 -e "ConnectionStrings:YourDB"="Your_Connection_String" sminseonong/petappapi:0.0.2`
## Docker Compose
Is a way to coordinate multiple containers together



- VM
- Zip vs Container deployment
- For Zip Deployment:
  - Download application specific runtime
  - Find built artifact
  - run that artifact
- For Container deployment:
  - install docker
  - pull the image
  - run the image