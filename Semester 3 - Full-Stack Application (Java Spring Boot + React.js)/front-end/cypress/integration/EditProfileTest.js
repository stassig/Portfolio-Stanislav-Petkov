describe('Editing Profile Information', () => {

    it('should edit personal information', () => {
        // Login
        cy.visit('/login')
            .get('#login-username').clear().type("test")
            .get('#login-password').clear().type("test")
            .get('#login-button').click()

        // Edit Profile
            .get('#options-button').click()
            .get('#account-page-button').click()
            .get('#account-first-name').clear().type("Stanislav")
            .get('#save-account-button').click();
        cy.wait(500)
            .visit('/options')
            .get('#account-page-button').click()
            .get('#account-first-name').clear().type("test")
            .get('#save-account-button').click();

        // Logout
        cy.wait(500)
            .get('#logout-button').click();
        cy.hash().should('eq', '');
    })
})