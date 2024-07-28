import { Given, Then, When } from '@cucumber/cucumber';

import { Ensure, equals } from '@serenity-js/assertions'
import { actorCalled, Cast, engage } from '@serenity-js/core'
import { CallAnApi, GetRequest, LastResponse, Send } from '@serenity-js/rest'

Given('the playwright menu is available', async function () {
    // Write code here that turns the phrase above into concrete actions
    // return 'pending';

    console.log("In playwright menu available step definition");


    await actorCalled('Apisitt').attemptsTo(
        Send.a(GetRequest.to('1')),             // 2) Send request
        Ensure.that(LastResponse.status(), equals(200)),  // 3) Verify response
    )
});

