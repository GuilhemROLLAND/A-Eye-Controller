Feature: A-Eye_root

    This file is designed to test the embedded system.

    Scenario: Set in auto mode
        Given the ip is "192.168.1.21"
        And the wanted mode is "mode auto"
        When I publish the TC on topic "toServer"
        Then I must receive "Process IA running" on topic "toClient"
        And I must view "start" on topic "toIA"

    Scenario: AI processing with boat
        Given The AI is waiting
        And I have an image "with" boat
        When I publish "start" on topic "toIA"
        Then I must receive "0" on topic "prediction"

    Scenario: AI processing without boat
        Given The AI is waiting
        And I have an image "without" boat
        When I publish "start" on topic "toIA"
        Then I must receive "1" on topic "prediction"

    Scenario: Set mode
            | mode   | ack                   |
            | auto   | Process IA running    |
            | manual | Mode capture manuelle |
            | video  | Mode video            |
        Given the ip is "192.168.1.21"
        When I publish the TC on topic "toServer"
        Then I must receive the ack on topic "toClient"
    
    Scenario: take manual picture
        Given the selected mode is "mode manual"
        And the TC means "take picture"
        When I publish the TC on topic "toServer"
        Then I must receive a picture
        And I must receive "Capture" on topic "toClient"

