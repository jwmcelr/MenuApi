import { Given, Then, When } from '@cucumber/cucumber';
import { spec } from 'pactum';

Given('the menu is available', async function () {
    // Write code here that turns the phrase above into concrete actions
    // return 'pending';
    await spec()
        .get('https://localhost:7235/api/Menu/1')
        // .withCore({ rejectUnauthorized: false })
        .expectStatus(200)
        .expectJsonLike({
            "id": 1,
            "items": [
                {
                    "id": 1,
                    "name": "Spaghetti",
                    "description": "A Delicious Noodly Dish with Spaghetti Sauce and Meatballs"
                },
                {
                    "id": 2,
                    "name": "Lasagna",
                    "description": "A plateful of Cheesy, Meaty Deliciousness"
                }
            ]
        });
});