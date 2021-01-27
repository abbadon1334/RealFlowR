## ![Logo](https://raw.githubusercontent.com/abbadon1334/RealFlowR/master/FlowR.DocFx/images/logo.svg) RealFlowR

[![Maintainability](https://api.codeclimate.com/v1/badges/b0dccaa467a682b7d5d2/maintainability)](https://codeclimate.com/github/abbadon1334/RealFlowR/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/b0dccaa467a682b7d5d2/test_coverage)](https://codeclimate.com/github/abbadon1334/RealFlowR/test_coverage)

WIP - [API Documentation](https://abbadon1334.github.io/RealFlowR/api/index.html)

## A low code library .NET for RealTime UI

Direct communication between SignalR and the DOM via JS to interact with UI.

The main goal is to create a full framework that allows real time interaction
using only server side .NET 5 __without touching HTML or JS__.

### v1.0

- [x] Define DomNode
- [x] Add Communication : Server -> Client
- [x] Add Communication with response : Server -> Client -> Server
- [x] Add Base HTMLTags
    - [x] Add Div
    - [x] Add Button
        - [x] Add Click Event with callback
    - [x] Add Input
        - [x] Add Collect Method : ask UI Element to get value from UI when needed
    - [ ] ~~Add Component Data Model to define data driven components~~
- [x] Tests
    - [x] Add SpecFlow test
    - [ ] Reach at least 80% of test coverage
    - [ ] Add Selenium for functional tests 
- [x] Add Runtime injection of js/css
- [x] Add Bootstrap5
- [ ] Add Bootstrap elements
- [ ] Add Entity Framework
    - [ ] Define in Component Method SetModel()
    - [ ] Test with Table


Did you like the idea? Contribute are always welcome.