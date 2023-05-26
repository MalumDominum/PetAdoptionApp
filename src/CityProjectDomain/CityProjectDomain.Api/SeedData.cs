using CityProjectDomain.Domain.Aggregates.ProjectAggregate;
using CityProjectDomain.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CityProjectDomain.Api;

public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider, bool isDevelopment)
    {
	    using var dbContext = new AppDbContext(
		    serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
	    if (isDevelopment && !dbContext.Projects.Any())
		    InsertProjectsForTesting(dbContext);
    }

	private static void InsertProjectsForTesting(AppDbContext context)
	{
		var publisherGuid = Guid.Parse("a0385d76-7f83-4016-bb5b-aa413959cf90");
		var insert = new List<Project>
		{
			new() {
				Title = "Cтерилізація хатніх тварин",
				Link = "https://gb.mistoboyarka.gov.ua/projects/archive/506/show/7",
				Description = "Опис проекту\r\nУ 2020 році у Боярці реалізується проект під назвою \"Безкоштовна стерилізація хатніх тварин\". Проект був позитивно прийнятий громадою, але кількість людей що не отримали послугу така, що є необхідність надати можливість стерилізувати своїх пухнастих і в 2021 році.\r\n\r\nПроблема\r\nЗа останні роки коштами міста стерилізовано близько 250 хатніх тварин для громадян, які не можуть собі цього дозволити. Та кількість бажаючих, що досі не мають можливості стерилізувати тварин ще залишається такою, що робить необхідним провести стерилізацію ще у 2021 році.\r\n\r\nМета проекту та яким чином проект вирішить проблему\r\nОчистити вулиці від нових безпритульних тварин, та фінансово підтримає небайдужих (до проблем тварин) людей.\r\n\r\nДля кого цей проект\r\nПроект спрямований на всіх громадян, які є власниками собак і кішок, але не мають коштів для їх стерилізації. Категорії мешканців, на які спрямований проект: 1.Малозабезпечені; 2.Пенсіонери за віком та професійною ознакою; 3.Інваліди 1,2,3 групи; 4.Ветерани війни.",
				CityName = "Боярка",
				PublisherId = publisherGuid,
				StartOfVoting = new DateTime(2020, 9, 29),
				EndOfVoting = new DateTime(2020, 12, 20),
				CreatedAt = new DateTime(2020, 9, 29)
			},
			new() {
				Title = "Cтерилізація хатніх тварин ч.2",
				Link = "https://gb.mistoboyarka.gov.ua/projects/archive/325/show/2",
				Description = "Опис проекту\r\nУ 2017 році у Чугуєві був реалізований подібний проект під назвою \"Безкоштовна стерилізація тварин, що належать жителям Чугуєва\". Він став унікальним для України і багато міст наразі планують скористатись прикладом Чугуєва.\r\nМи боярчани знаходимось поблизу столиці України і саме ми, маємо підтримати добру справу по оздоровленю громади у ставлені до тих, за кого ми відповідальні!!\r\nМи плануємо простерилізувати 250 тварин, серед яких: 50 собак невеликої породи, 50 собак великої породи, 50 котів та 100 кішок.\r\n\r\nПроблема\r\nБагато років волонтери м. Боярка забирають з вулиць безпритульних тварин, лікують, стерилізують та прилаштовують у хороші руки. Але вулиці міста знову наповнюються викинутими собаками і кішками.\r\nЗ кожним роком кількість викинутих (власниками!) кошенят та цуценят приголомшливо велика! Через брак коштів на стерилізацію, мешканці міста викидають тварин, підкидають під будинки, також були зухвалі випадки вбивств тварин, навіть закопували живцем! Необхідно працювати з причиною, а не розгрібати наслідки!\r\nКоштами благодійників та міста стерилізовано більшість безпритульних тварин, тепер важливо за допомогою місцевого бюджету провести стерилізацію тварин для громадян міста, які не можуть собі цього дозволити.\r\n\r\nМета проекту\r\n1. Очистити вулиці від нових безпритульних тварин.\r\n2. Захист від розповсюдження захворювань, що коти та собаки переносять.\r\n2. Уникнення жорстокого поводження з усіма тваринами.",
				CityName = "Боярка",
				PublisherId = publisherGuid,
				StartOfVoting = new DateTime(2021, 09, 19),
				EndOfVoting = new DateTime(2021, 09, 19),
				CreatedAt = new DateTime(2021, 09, 19)
			},
			new() {
				Title = "\"Простір для вільного вигулу та розвитку собак\"",
				Link = "",
				Description = "",
				CityName = "",
				PublisherId = publisherGuid,
				StartOfVoting = DateTime.Now,
				EndOfVoting = DateTime.Now.AddDays(25),
				CreatedAt = DateTime.Now
			},
			new() {
				Title = "\"Простір для вільного вигулу та розвитку собак\"",
				Link = "",
				Description = "",
				CityName = "",
				PublisherId = publisherGuid,
				StartOfVoting = DateTime.Now,
				EndOfVoting = DateTime.Now.AddDays(25),
				CreatedAt = DateTime.Now
			},
			new() { 
				Title = "\"Простір для вільного вигулу та розвитку собак\"",
				Link = "",
				Description = "",
				CityName = "",
				PublisherId = publisherGuid,
				StartOfVoting = DateTime.Now,
				EndOfVoting = DateTime.Now.AddDays(25),
				CreatedAt = DateTime.Now
			},
			new() {
				Title = "Еко-парк \"Старт\"",
				Link = "",
				Description = "",
				CityName = "Київ",
				PublisherId = publisherGuid,
				StartOfVoting = DateTime.Now,
				EndOfVoting = DateTime.Now.AddDays(25),
				CreatedAt = DateTime.Now
			},
			new() {
				Title = "Песопарк - площадка для безповідкового вигулу собак",
				Link = "",
				Description = "",
				CityName = "Київ",
				PublisherId = publisherGuid,
				StartOfVoting = DateTime.Now,
				EndOfVoting = DateTime.Now.AddDays(25),
				CreatedAt = DateTime.Now
			},
			new() {
				Title = "Облаштування скверу \"Дружба\" (бул.Дружби Народів між буд. 20-22)",
				Link = "",
				Description = "",
				CityName = "Київ",
				PublisherId = publisherGuid,
				StartOfVoting = DateTime.Now,
				EndOfVoting = DateTime.Now.AddDays(25),
				CreatedAt = DateTime.Now
			},
			new() {
				Title = "100 дерев на Подолі",
				Link = "",
				Description = "",
				CityName = "Київ",
				PublisherId = publisherGuid,
				StartOfVoting = DateTime.Now,
				EndOfVoting = DateTime.Now.AddDays(25),
				CreatedAt = DateTime.Now
			}
		};
		foreach (var row in insert)
			context.Projects.Add(row);

		context.SaveChanges();
	}
}
