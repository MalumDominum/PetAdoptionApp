## GET PetProfile/{id} example 🐈

```json
{
	"id": "7850c317-bc14-4ad1-8a46-1fc9612e5601",
	"name": "Alice",
	"gender": "f",
	"birthDate": {
		"year": 2022,
		"month": 12,
		"date": null // May be optional if not sure exact date
	},
	// Not returned if photos present
	"appearance": {
		"species": {
			"id": 1,
			"title": "Cat"
		},
		"colors": [
			// Sorted by id
			{ "id": 1, "name": "White", "hexValue": "#ffffff" },
			{ "id": 5, "name": "Gray", "hexValue": "#808080" }
		]
	},
	"size": { "id": 1, "title": "Small", "from": 0, "to": 10 },
	"details": {
		"breed": { "id": "1", "value": "Unbred" },
		"neutering": true,
		"healthy": false,
		"vaccination": true,
		"hasPassport": true,
		"hasCollar": true,
		"goingWith": ["b086b71c-1e2e-46ce-b08d-0357f46919b2"] // For
	},
	"descriprion": "**A short story:**\nA kitten😻 - gray-haired beauty Alice...",
	"address": {
		"location": { "latitude": 50.442888, "longitude": 30.520436 },
		"value": "Kyiv, Kyiv region, 54 Khreshchatyk str., apt. 5"
	},
	"states": {
		"active": [
			// Ordered by title
			{
				"id": 1,
				"title": "Looking for a home",
				"assignedDate": "08/03/2023"
			},
			{
				"id": 5,
				"title": "Needs a donation",
				"assignedDate": "08/03/2023"
			}
		],
		"history": [
			// Ordered by resolvedDate
			{
				"id": 4,
				"title": "Losted",
				"assignedDate": "18/01/2023",
				"resolvedDate": "27/01/2023"
			},
			{
				"id": 7,
				"title": "Needs to be overstayed",
				"assignedDate": "13/03/2022",
				"resolvedDate": "17/03/2023"
			}
		]
	},
	"photoAndVideoUrls": [
		// Order by int Place, that implemented under the hood but not returned || Or by ending _1 || Value can be cutted to "1.png" - id will be added at frontend
		"7850c317-bc14-4ad1-8a46-1fc9612e5601_1.jpeg",
		"7850c317-bc14-4ad1-8a46-1fc9612e5601_2.mp3",
		"7850c317-bc14-4ad1-8a46-1fc9612e5601_3.png"
	],
	"owner": {
		"id": "a2b8e54a-2063-40c9-822c-480ba7b63a50",
		"name": "Georg Novikov",
		"avatarUrl": "a2b8e54a-2063-40c9-822c-480ba7b63a50.jpeg",
		"isPetShelter": false,
		"isVolunteer": true
	},
	"createdAt": "13/03/2022 17:03", // g Format, es-ES Culture
	"editedAt": "08/03/2023 09:39",
	// "statusChangedTime": "08/03/2023 09:39" - Only for orderBy
	"wasSaved": true // Not returns if not logged in
}
```

## GET PetProfile?fromTime={statusChangedTime}&filter={value} example 📃🐈🐈🐈

##### Filtering options with examples (Maked class for passing this values)

```url
?nameLike=Ali
?speciesId=1
?breedId=1
?nearLocation={ "latitude": 50.442888, "longitude": 30.520436}
?stateIds[0]=1&stateIds[1]=5
?gender=f
?height={ "from": 10, "to": 35 }
?birthDate={ "from": 13.03.2022, "to": null }
?colorIds[0]=1 & colorIds[1]=3 & colorIds[2]=6

?neutering=true
?healthy=false
?vaccination=true
?hasCollar=true

?wasSaved=true
```

##### Paginated results (Limit is static) with filtering

```json
{
	"result": [
		{
			"id": "7850c317-bc14-4ad1-8a46-1fc9612e5601",
			"name": "Alice",
			"gender": "f",
			"birthDate": {
				"year": 2022,
				"month": 12,
				"day": null
			},
			"speciesTitle": "Cat",
			"colors": [
				// Not returned if photo present || Sorted by id
				{ "id": 1, "name": "White", "hexValue": "#ffffff" },
				{ "id": 5, "name": "Gray", "hexValue": "#808080" }
			],
			"size": { "id": 1, "title": "Small", "from": 0, "to": 10 },
			// OR if status Losted or Founded
			"hasCollar": true,
			"activeStates": [
				{
					"id": 1,
					"title": "Looking for a home",
					"assignedDate": "08/03/2023"
				},
				{
					"id": 5,
					"title": "Needs a donation",
					"assignedDate": "08/03/2023"
				}
			],
			"mainPhotoUrl": "7850c317-bc14-4ad1-8a46-1fc9612e5601_1.jpeg",
			"wasSaved": true // Not returns if not logged in
		}
        ...
        { result №20 } // Configurable with "PageSize"
	],
	"pagination": {
		"currentPageNumber": 6,
		"lastPageNumber": 7,
		"totalResultsCount": 132,
		"pages": {
			"first": "https://domain.de/api/petProfiles",
			"beforePreviousPage": "https://domain.de/api/petProfiles?Page=4",
			"previousPage": "https://domain.de/api/petProfiles?Page=5",
			"nextPage": "https://domain.de/api/petProfiles?Page=7",
			"afterNextPage": null,
			"lastPage": "https://domain.de/api/petProfiles?Page=7"
		}
	}
}
```
