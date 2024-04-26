# HTD Lab Setup Instructions

The utility to access labs is written in Java, and packaged as a jar. So, you will at minimum need a JRE of version 11 or higher to access it. You can check this by running the command `java –version`.
 
Have your git config set up. I assume that you all have it set up such that you are already able to push, but you will definitely need to check that the following values are not blank by running `git config user.name` and `git config user.email`. They should be set to your username and email. If you don't do this, the utility will refuse to run.
 
You will need to be added to this org: https://github.com/htd-labs. If you are logged in and can only see a couple repositories (there should be several pages worth), then that means your account hasn’t been invited yet, or you haven’t accepted the invitation yet.
 
Clone this repo: https://github.com/htd-labs/labs-utility-nj-react and open the repo as a project in your IDE. It should have the necessary jar file, labs.jar, at the ROOT level of the project.
 
Now you can run the command `java -jar labs.jar` to access the utility. You should run the command `check` when prompted for a command to verify that your setup is complete - what this will do is verify that you can access private content on the org and save progress.
 
Any lab that is listed in the readme.md can be accessed using the open command - such as running `open react-state` when you have been prompted by the utility. The lab contents will be dropped in a folder called ‘lab’ in your project. You can work on the labs in the order provided in the readme. Progress on the labs will automatically be saved when you open a different lab - so, if you reopen a previous lab, your previous work will be pulled from github.
 
This set of labs doesn’t have operable test cases, and you can just ignore the ones that are provided in the JS labs. They are written in Selenium, and it isn't worth the effort to configure your environments to use it.  It will be more straightforward and productive for you to rely on browser feedback, by either opening the .html file in your browser for js labs or by serving the react app. These labs will have their instructions visible from the browser.
 
React labs will first require you to download the necessary dependencies FOR EVERY LAB by first changing your terminal’s directory into the `lab` folder and running `npm install`. Naturally, you should have installed an appropriate version of node + npm by this point.