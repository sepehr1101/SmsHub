# Feature Branch Workflow
We use [feature branching](https://martinfowler.com/bliki/FeatureBranch.html) to work on new features or tasks in our open-source project. Each feature or task gets its own separate branch in our code. This helps us develop and test things without messing up the main code. Once a feature is done and tested, we merge it back into the main code. It keeps our work organized, lets us work together, and makes it easier to handle multiple tasks at once.

# Contribution Guide: Using Feature Branches
1- Create a branch in line with our Branch Naming Conventions.
2- Check out the branch on your local environment (e.g., Visual Studio).
3- Commit your changes following our commit conventions.
4- Push your commits and submit a Pull Request from your fork to the Taskomask master branch.
5- Our team will review your code and gladly welcome you as a contributor!

# Branch Naming Conventions
Branch name should be structured as follows:

```
<type>-<issueId>-<name>

```

# Type
type must be one of the following:

- **bug**: Something isn't working
- **documentation**: Improvements or additions to documentation
- **duplicate**: This issue or pull request already exists
- **feature**: New feature or request
- **formatting**: style, intendency, .etc
- **help wanted**: Extra attention is needed
- **question**: Further information is requested
- **refactor**: Code refactoring
- **test**: request for test, wring test, testing overally
- **won`t fix**: This will not be worked on

## IssueId
Issue Id related to the branch.

## Name
- Choose a short name related to the issue
- Don't capitalize the first letter
- No dot (.) at the end
- Separate words with "-"

## Examples

```
fix-26-prevent-inactive-user-login

```

(Accepted from [feature branching](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/Branch-Conventions.md))
