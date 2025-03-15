|#|Use case|Requires auth?|Rules|
|-|-|-|-|
|1|As a patron, I want to register for a new account as a "general" cardholder type|No|Inputs for the new account must be valid|
|2|As a patron, I want to register for a new account as a "junior" cardholder type|No|Inputs for the new account must be valid|
|3|As an admin, I want to register for a new account|No|Inputs for the new account must be valid|
|4|As a patron, I want to log in to my account|No|Inputs for the log in must be valid, there cannot already be an account logged in|
|5|As an admin, I want to log in to my account|No|Inputs for the log in must be valid, there cannot already be an account logged in|
|6|As a patron, I want to log out of my account|Yes|none|
|7|As an admin, I want to log out of my account|Yes|none|
|8|As a patron, I want to change my account password|Yes|Inputs for the password change must be valid, must provide valid current password|
|9|As an admin, I want to change my account password|Yes|Inputs for the password change must be valid, must provide valid current password|
|10|As a patron, I want to browse the library's catalogs of materials|Yes|Catalog's cardholder types must include the patron's cardholder type|
|11|As an admin, I want to browse the library's catalogs of materials|Yes|none|
|12|As a patron, I want to place holds on catalog materials|Yes|none|
|13|As a patron, I want to remove holds that I have placed on catalog materials|Yes|Hold to be removed must belong to the patron|
|14|As a patron, I want to extend a checkout|Yes|Checkout to be extended must belong to the patron, the patron must not have unpaid fines, a checkout can be extended only once, which adds seven (7) days to checkouts of books and magazines, or three (3) days to checkouts of video cassettes|
|15|As a patron of cardholder type "general", I want to make payments towards unpaid fines that belong to myself or any other patron|Yes|No overpayments, if paid in full the fine becomes historical|
|16|As a patron, I want to see a patron summary that shows my holds, checkouts, overdue checkouts, unpaid fines, checkout history, and fine history|Yes|none|
|17|As an admin, I want to create checkouts for materials on hold|Yes|Material to be checked out cannot already be checked out, material to be checked out must have a hold that is the oldest by date created, patron the hold belongs to must not have any unpaid fines, a patron can have no more than five (5) materials checked out at a time, book and magazine checkouts are for fourteen (14) days, video cassette checkouts are for seven (7) days|
|18|As an admin, I want to close checkouts|Yes|If material is overdue a fine is created, the checkout becomes historical|
|19|As an admin, I want to see checkouts for the library|Yes|none|
|20|As an admin, I want to see overdue checkouts for the library|Yes|none|
|21|As an admin, I want to see holds for the library|Yes|none|
|22|As an admin, I want to see unpaid fines for the library|Yes|none|
|23|As an admin, I want to see checkout history for the library|Yes|none|
|24|As an admin, I want to see fine history for the library|Yes|none|