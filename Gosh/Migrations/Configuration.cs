namespace Gosh.Migrations
{
    using Gosh.Controllers;
    using Gosh.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI;

    internal sealed class Configuration : DbMigrationsConfiguration<Gosh.Models.MyDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gosh.Models.MyDB context)
        {
            //  This method will be called after migrating to the latest version.

            AddCategories(context);
            AddRecipies(context);
    //        AddUserRecipePreference(context);
            CreateAdmin(context);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }


        void CreateAdmin(Gosh.Models.MyDB context)
        {
            User admin = new User();
            admin.FirstName = "Admin";
            admin.LastName = "Admin";
            admin.Password = "Aa123456!";
            admin.ConfirmPassword = "Aa123456!";
            admin.Mail = "admin@gosh.com";
            admin.PhoneNumber = "+972-557-0555-12";
            admin.Username = "ADMIN";
            admin.ID = 1;
            Password p = Password.Create(admin.Password);
            p.UserID = admin.ID;
            p.User = admin;
            p.ID = 1;

            context.Users.AddOrUpdate(admin);
            context.Passwords.AddOrUpdate(p);



        }

        void AddCategories(Gosh.Models.MyDB context)
        {

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Italiano",
                ImagePath = "Italiano.jpg",
                RepresetingArea = "Italy",
                WeatherHref = "/41d9012d50/rome/",
                ID = 1
            });


            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "French",
                ImagePath = "French.jpg",
                RepresetingArea = "France",
                WeatherHref = "/48d862d35/paris/",
                ID = 2
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Israeli",
                ImagePath = "Israeli.jpg",
                RepresetingArea = "Israel",
                WeatherHref = "/31d7735d21/jerusalem/",
                ID = 3
            });


            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Japanese",
                ImagePath = "Japanese.jpg",
                RepresetingArea = "Japan",
                WeatherHref = "/35d71139d73/tokyo/",
                ID = 4
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Brazilian",
                ImagePath = "Brazilian.jpg",
                RepresetingArea = "Brazil",
                WeatherHref = "/n22d91n43d17/rio-de-janeiro/",
                ID = 5
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Russian",
                ImagePath = "Russian.jpg",
                RepresetingArea = "Russia",
                WeatherHref = "/55d7637d62/moscow/",
                ID = 6
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Greek",
                ImagePath = "Greek.jpg",
                RepresetingArea = "Greece",
                WeatherHref = "/39d0721d82/greece/",
                ID = 7
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Australian",
                ImagePath = "Australian.jpg",
                RepresetingArea = "Australia",
                WeatherHref = "/n33d87151d21/sydney/",
                ID = 8
            });
            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Chinese",
                ImagePath = "Chinese.jpg",
                RepresetingArea = "China",
                WeatherHref = "/31d23121d47/shanghai/",
                ID = 9
            });
        }

        void AddRecipies(Gosh.Models.MyDB context)
        {
            Random rnd = new Random();
            int id = 1;
            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 3,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"600ml (1 pint) warm water (45 C)
1 tablespoon dried active baking yeast
7 tablespoons honey
4 tablespoons vegetable oil
3 eggs
1 tablespoon salt
1kg (2 1/4 lb) plain flour
1 tablespoon poppy seeds (optional)
",
                Header = "Challah",
                Content = @"In a large bowl, sprinkle yeast over warm water. Beat in honey, oil, 2 eggs and salt. Add the flour in small amounts, beating after each addition, graduating to kneading with hands as dough thickens. Knead until smooth and elastic and no longer sticky, adding flour as needed. Cover with a clean damp cloth and let rise for 1 1/2 hours or until dough has doubled in size.
Punch down the risen dough and turn out onto floured board. Divide in half and knead each half for five minutes or so, adding flour as needed to keep from getting sticky. Divide each half into thirds and roll into long snake about 4cm (1 1/2 in) in diameter. Pinch the ends of the three snakes together firmly and plait from middle.
Grease two baking trays and place a finished plait on each. Cover with towel and let rise about one hour.
Preheat oven to 190 C / Gas mark 5.
Beat the remaining egg and brush a generous amount over each plait. Sprinkle with poppy seeds if desired.
Bake in preheated oven for about 40 minutes. Bread should have a nice hollow sound when tapped on the bottom. Cool on a rack for at least one hour before slicing.
",
                HomeImageUrl = "Recipes/Challah.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 3,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"675g beef fillet, well trimmed and cubed
4 tablespoons butter, divided
8 tablespoons finely chopped shallots
175g sliced mushrooms
500ml beef stock
3 teaspoons cornflour
250ml soured cream
2 teaspoons Dijon mustard
salt to taste
",
                Header = "Foolproof Beef Stroganoff",
                Content = @"Over medium high heat, gently cook beef in 2 tablespoons of butter for about 2 minutes, until just seared on all sides. You will still be able to see red. Remove from pan and set aside in a rimmed dish or baking tray so that you collect the juices.
Return the pan to medium-high heat and cook the shallots and mushrooms in remaining butter until soft, about 5 minutes. Mix cornflour into cold beef stock, whisk to blend. Pour into pan, and stir together with shallots and mushrooms until thickened, two or three minutes.
Add soured cream and mustard, and stir. Add beef and juices from dish; stir over medium heat just till warmed through. Salt to taste.
",
                HomeImageUrl = "Recipes/Foolproof Beef Stroganoff.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 3,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1 tablespoon olive oil
1 onion, finely chopped
2 red chillies, finely chopped
1 pinch chilli flakes, or to taste
4 garlic cloves, crushed
400g passata
200ml vegetable stock
400g beef mince
1 teaspoon dried oregano
1 teaspoon dried basil
1 tablespoon tomato puree
salt and pepper to taste
2 Camembert wheels
300g spaghetti
",
                Header = "Spaghetti and meatballs with Camembert in arrabiata sauce",
                Content = @"Add oil to a pan and fry the onion for 5 minutes, until soft. Add the fresh and dried chilli, cook for 1 minute, then add half of the garlic. Pour in the passata and stock. Bring to the boil, then reduce heat and cover; simmer for 20 minutes.
Meanwhile mix the beef mince, remaining garlic, oregano, basil and tomato puree and shape into about 12 balls. Fry the balls in a little oil for 10 minutes until browned all over.
Bring a large pan of salted water to the boil; boil the spaghetti for 10 minutes, or as directed on the packet.
Add the meatballs to the sauce and continue cooking till cooked through.
Slice the Camembert horizontally and place on a baking tray skin side down under a pre-heated grill for 5 minutes or until golden brown on top.
Add the cooked spaghetti to bowls, then pour over the meatballs and sauce finally place the Camembert on top, skin side up.
",
                HomeImageUrl = "Recipes/Spaghetti and meatballs with Camembert in arrabiata sauce.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 1,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"4 baguette or crusty bread slices
2 garlic cloves, peeled
2 tomatoes, cored and chopped
Salt, to season
8 fresh basil leaves, torn or chopped
1 or 2 tablespoons extra virgin olive oil
",
                Header = "Italian bruschetta",
                Content = @"Place the bread on a baking tray and toast both sides under the grill until golden brown.
While the bread is still warm, rub one side of each piece of toast with a garlic clove, top with chopped tomatoes, a little salt and fresh basil. Drizzle olive oil over the top and serve.
",
                HomeImageUrl = "Recipes/Italian bruschetta.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 7,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1-2 tbsp olive oil Olive oil ol-iv oylProbably the most widely-used oil in cooking, olive oil is pressed from fresh olives. It'sâ€¦
Â½ tsp zaâ€™atar Zaâ€™atar zar-uh-tarThis Middle Eastern and Levantine flavouring changes lives onceâ€¦
225g pack halloumi, sliced Halloumi ha-loo-meeA semi-hard chewy, white cheese originating from Cyprus and made from cow's, goat's orâ€¦
5 cherry tomatoes, halved
1 tbsp pomegranate molasses
handful mint leaves, to serve
1-2 tsp pomegranate seeds, to serve
",
                Header = "Halloumi with tomatoes & pomegranate molasses",
                Content = @"Pour the olive oil into a medium bowl, add the zaâ€™atar and stir to combine. Add the halloumi and toss in the mixture until well coated.
Heat a large griddle pan. Place the halloumi in the pan and cook for 1-2 mins, then turn over and cook for a further 1-2 mins until golden brown on both sides. After turning the halloumi, add the cherry tomatoes and move them around the pan quickly so they cook all over.
Transfer the halloumi and tomatoes to a plate, then drizzle over the pomegranate molasses and serve with the mint leaves and pomegranate seeds scattered over.
",
                HomeImageUrl = "Recipes/Halloumi with tomatoes & pomegranate molasses.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 7,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"450ml chicken stock, from a cube (I use Kallo, organic)
100ml white wine
2 garlic cloves, finely chopped
3 thyme sprigs ThymeThis popular herb grows in Europe, especially the Mediterranean, and is a member of the mintâ€¦
1 tarragon sprig, plus 1 tbsp chopped tarragon leaves Tarragon ta-ra-gonA popular and versatile herb, tarragon has an intense flavour that's a unique mix of sweetâ€¦
225g carrots, cut into batons Carrot ka-rotThe carrot, with its distinctive bright orange colour, is one of the most versatile rootâ€¦
4 skinless chicken breasts, 500g/1lb 2oz total weight
225g leeks, sliced Leek lee-kLike garlic and onion, leeks are a member of the allium family, but have their own distinctâ€¦
2 tbsp cornflour, mixed with 2 tbsp water
3 tbsp crÃ¨me fraÃ®che
1 heaped tsp Dijon mustard
1 heaped tbsp chopped flat-leaf or curly parsley Parsley par-sleeOne of the most ubiquitous herbs in British cookery, parsley is also popular in European andâ€¦
70g filo pastry (I used three 39 x 30cm sheets)
1 tbsp rapeseed oil Rapeseed oilIf you want a light alternative to other cooking oils, rapeseed is a great choice and hasâ€¦
",
                Header = "The ultimate makeover-Chicken pie",
                Content = @"Pour the stock and wine into a large, wide frying pan. Add the garlic, thyme, tarragon sprig and carrots, bring to the boil then lower the heat and simmer for 3 mins. Lay the chicken in the stock, grind over some pepper, cover and simmer for 5 mins. Scatter the leek slices over the chicken, cover again then gently simmer for 10 more mins, so the leeks can steam while the chicken cooks. Remove from the heat and let the chicken sit in the stock for about 15 mins, so it keeps moist while cooling slightly.
Strain the stock into a jug â€“ you should have 500ml (if not, make up with water). Tip the chicken and veg into a 1.5 litre pie dish and discard the herb sprigs. Pour the stock back into the sautÃ© pan, then slowly pour in the cornflour mix. Return the pan to the heat and bring to the boil, stirring constantly, until thickened. Remove from the heat and stir in the crÃ¨me fraÃ®che, mustard, chopped tarragon and parsley. Season with pepper. Heat oven to 200C/180C fan/gas 6.
Tear or cut the chicken into chunky shreds. Pour the sauce over the chicken mixture, then stir everything together.
Cut each sheet of filo into 4 squares or rectangles. Layer them on top of the filling, brushing each sheet with some of the oil as you go. Lightly scrunch up the filo so it doesnâ€™t lie completely flat and tuck the edges into the sides of the dish, or lay them on the edges if the dish has a rim. Grind over a little pepper, place the dish on a baking sheet, then bake for 20-25 mins until the pastry is golden and the sauce is bubbling. Serve immediately.
",
                HomeImageUrl = "Recipes/The ultimate makeover-Chicken pie.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 2,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"250g fresh ravioli or tortellini
1 papaya, cut into quarters
2 tomatoes, cut into wedges
1/2 cucumber, sliced
1/2 cantaloupe melon, cut into quarters
100g bag mixed rocket, spinach and watercress salad
2 tablespoons balsamic vinegar
2 tablespoons extra virgin olive oil
1 teaspoon Dijon mustard
1 teaspoon runny honey
1 garlic clove, crushed
1 tablespoon sunflower seeds and brown linseeds
",
                Header = "Ravioli summer salad",
                Content = @"Bring a saucepan of water to the boil and add the pasta. Cook according to the instructions on the packet or until al dente. Remove from the heat, drain and allow to cool, about 20 minutes.
In a large salad bowl combine the papaya, tomatoes, cucumber, melon, salad leaves and pasta.
Make the dressing by combining the remaining ingredients, except the seeds, and whisking together. Pour the dressing on top and toss to combine.
In a dry frying pan over a medium heat, toast the seeds until fragrant, taking care not to burn. Sprinkle over the salad and serve.
",
                HomeImageUrl = "Recipes/Ravioli summer salad.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 4,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1 tbsp sunflower oil Sunflower oilA variety of oils can be used for baking. Sunflower is the one we use most often at Good Food asâ€¦
5 tbsp soy sauce Soy sauce soy sor-sAn Asian condiment and ingredient that comes in a variety of of varieties ranging from light toâ€¦
5 tbsp mirin or dry sherry
1 tbsp golden caster sugar
1 piece fresh root ginger, peeled and finely grated
2 garlic cloves, crushed to a paste
4 frozen boneless, skinless salmon fillets
1 small cucumber
1 tbsp rice wine vinegar
1 tbsp soy sauce Soy sauce soy sor-sAn Asian condiment and ingredient that comes in a variety of of varieties ranging from light toâ€¦
Â½ tsp golden caster sugar
1 tbsp toasted sesame seeds
",
                Header = "Grilled salmon teriyaki with cucumber salad",
                Content = @"Heat the grill to high and brush a sturdy baking tray with oil. In a large bowl, mix the soy, mirin, sugar, ginger and garlic together until the sugar has dissolved, then toss the frozen salmon in the soy mix until coated. Tip the remaining marinade into a small saucepan and bring to a simmer.
Place the tray about 4in away from the heat, then grill for 20 mins. Brush the fish every few mins with the simmering marinade until cooked through and glazed. If the fillets are thick, you may need to turn them on their sides so they cook evenly. Remove from the grill. Simmer the marinade until sticky, then pour it over the cooked salmon.
For the cucumber salad, use a swivel blade peeler to peel the cucumber into slices. Make the dressing by mixing the vinegar with the soy sauce, sugar and sesame seeds. Toss the cucumber with the dressing and serve with the salmon and boiled rice.
",
                HomeImageUrl = "Recipes/Grilled salmon teriyaki with cucumber salad.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 7,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"",
                Header = "The ultimate makeover-Chicken pie",
                Content = @"",
                HomeImageUrl = "Recipes/The ultimate makeover-Chicken pie.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 2,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"100g bulgar wheat
100g kale Kale kay-elA member of the cabbage family, kale comes in two forms: kale, which has smooth leaves, andâ€¦
large bunch mint, roughly chopped Mint mi-ntThere are several types of mint, each with its own subtle difference in flavour and appearance.â€¦
bunch spring onion, sliced Spring onion sp-ring un-yunAlso known as scallions or green onions, spring onions are in fact very young onions, harvestedâ€¦
Â½ cucumber, diced
4 tomatoes, deseeded and chopped Tomato toe-mart-ohA member of the nightshade family (along with aubergines, peppers and chillies), tomatoes are inâ€¦
pinch of ground cinnamon
pinch of ground allspice
6 tbsp olive oil Olive oil ol-iv oylProbably the most widely-used oil in cooking, olive oil is pressed from fresh olives. It'sâ€¦
juice and zest Â½ lemon Lemon le-monOval in shape, with a pronouced bulge on one end, lemons are one of the most versatile fruitsâ€¦
100g feta cheese, crumbled
4 Baby Gem lettuces, leaves separated, to serve",
                Header = "Kale tabbouleh",
                Content = @"Tip the bulghar wheat into a heatproof bowl and just cover with boiling water, then cover with cling film and set aside for 10-15 mins or until tender. Put the kale in a food processor and pulse to finely chop.
Stir the kale, mint, spring onions, cucumber and tomatoes through the bulghar wheat. Season with the cinnamon and allspice, then dress with the olive oil and lemon juice to taste. Scatter over the lemon zest and feta. To serve, let everyone scoop the salad onto leaves of Baby Gem lettuce.
",
                HomeImageUrl = "Recipes/Kale tabbouleh.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 8,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1 small pack frozen raspberries
sugar
4 scoops good vanilla ice cream
whipped cream (optional)
",
                Header = "Raspberry vanilla sundae",
                Content = @"Bring the raspberries to the boil in a small pan to draw out the juice. Strain through a sieve and add sugar to the juice to taste (you can also prepare the sauce whenever you like and reheat it later).
Put two scoops of vanilla ice cream into a sundae glass and pour the hot sauce over it. If you like, add whipped cream. Serve immediately.
",
                HomeImageUrl = "Recipes/Raspberry vanilla sundae.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 8,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"2 x 7g sachets fast-action dried yeast
600g '00' flour, sponge flour or plain flour, plus extra for dusting Flour fl-ow-erFlour is a powdery ingredient usually made from grinding wheat, maize, rye, barley or rice. Asâ€¦
50g golden caster sugar
400ml warm milk Milk mill-kOne of the most widely used ingredients, milk is often referred to as a complete food. While cowâ€¦
50g melted salted butter, plus extra for greasing and to serve
1 large egg, beaten
200g jar Nutella, plus extra to serve (optional)
200g raspberries
1-2 tbsp chopped hazelnut Hazelnut hay-zl-nutGrown in Europe and the US, hazelnuts are encased in a smooth, hard brown shell but are mostâ€¦
1 tbsp granulated sugar
raspberry jam, to serve
",
                Header = "Raspberry, chocolate & hazelnut breakfast bread",
                Content = @"Up to 3 days before you want to bake (and best if at least 1 day), mix the yeast, 400g of the flour, the sugar and 1 tsp salt in a big bowl. Whisk together the milk, melted butter and egg, then tip into the dry ingredients and mix with a wooden spoon. Cover tightly with greased cling film and chill at least overnight or up to 3 days.
When youâ€™re ready to finish the bread, heat oven to 180C/160C fan/gas 4. Add the remaining flour to the dough and use your hands to mix in. Tip onto a lightly floured surface and lightly knead to completely bring together. Roll out with a little more flour to a 50 x 30cm rectangle. Spread the Nutella all over the dough. Scatter the raspberries evenly over, then press lightly with your hands so they stick into the dough a bit.
With a long side facing you, roll up as tightly as you can (like a Swiss roll). Use a sharp knife, dusted with a little flour, to cut the roll in half down the length â€“ but not quite through at one end, so the 2 strips are still joined. Twist the 2 strips together, then bring the ends together to make a wreath, pinching the ends together to stick. Lift onto a baking sheet, scatter with the hazelnuts and granulated sugar, and bake for 30-40 mins until browned and crusty.
Cool until just warm. Serve with butter, raspberry jam and extra Nutella, if you like.
",
                HomeImageUrl = "Recipes/Kale tabbouleh.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 8,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1 large or 2 smaller aubergines (about 400g in total) Aubergine oh-ber-geenAlthough it's technically a fruit (a berry, to be exact), the aubergine is used as aâ€¦
1 tbsp coriander seed Coriander seed kor-ee-and-er seedThe small, creamy brown seeds of the coriander plant give dishes a warm, aromatic and slightlyâ€¦
1 tbsp cumin seed
3 tbsp extra virgin olive oil, plus extra for drizzling Olive oil ol-iv oylProbably the most widely-used oil in cooking, olive oil is pressed from fresh olives. It'sâ€¦
handful fresh parsley leaves Parsley par-sleeOne of the most ubiquitous herbs in British cookery, parsley is also popular in European andâ€¦
Greek yogurt, to serve
seeds from Â½ ripe pomegranate
",
                Header = "Roasted aubergine with pomegranates & parsley",
                Content = @"Heat oven to 180C/160C fan/gas 4. Halve the aubergines lengthways, then chop them into cubes, about 2.5cm across. Transfer to a large bowl.
Using a pestle and mortar or small food processor, break the coriander and cumin seeds down a little, so that they are crushed but not ground to a powder. Add them to the aubergines. Next add the olive oil and a good pinch of salt and pepper. Use your hands and turn the aubergines over in the oil and spices until evenly coated. Tip onto a baking tray that can hold the aubergines in a single layer. Cook for 30-35 mins, turning once, until crisp, dark at the edges and utterly squashy.
Cool to almost to room temperature before transferring to a bowl and mixing in the parsley. Season, then drizzle with a little oil. Dollop over yogurt and scatter with pomegranate seeds before serving.
",
                HomeImageUrl = "Recipes/Roasted aubergine with pomegranates & parsley.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 8,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"300g fresh raspberries
4 tablespoons caster sugar
2 tablespoons orange juice
2 tablespoons cornflour
250ml cold water
",
                Header = "Raspberry Sauce",
                Content = @"Combine the raspberries, sugar and orange juice in a saucepan. Whisk the cornflour into the cold water until smooth. Add the mixture to the saucepan and bring to the boil.
Simmer for about 5 minutes, stirring constantly, until the desired consistency is reached. The sauce will thicken further as it cools.
Puree the sauce in a blender or with a handheld immersion blender and strain it through a fine sieve. Serve warm or cold. The sauce will keep in the refrigerator for up to two weeks.
",
                HomeImageUrl = "Recipes/Raspberry Sauce.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 8,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"256g self-raising flour
1 teaspoon mustard powder
1 pinch paprika
1 pinch dried mixed herbs
2 tablespoons butter, at room temperature
170g grated cheese
80ml water
VegemiteÂ®
",
                Header = "Australia Day Vegemite pinwheels",
                Content = @"Preheat the oven to 220 C / Gas 7.
In a large mixing bowl sift in the flour, mustard and paprika. Add the herbs. Using your fingertips rub in the butter. Add the cheese and mix well. Add the water and mix to a dough.
On a lightly floured surface knead the pastry until it is a firm dough.
Roll out pastry into a thin rectangle. Spread the Vegemite all over (be careful to spread lightly as Vegemite is quite strong in taste).
Roll up into a long coil. Cut with a sharp knife into pinwheels 5mm thick. Place onto greased baking trays.
Bake for 10 to 14 minutes. Using a spatula, carefully remove to cool on a wire rack.
",
                HomeImageUrl = "Recipes/Australia Day Vegemite pinwheels.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 1,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1 vanilla bean
250ml milk
150g cream
50g sugar
3 sheets gelatine
4 tablespoons raspberry jam
",
                Header = "Panna cotta with raspberry cream",
                Content = @"Cut open the vanilla bean lengthways and scrape out the pulp. Put the milk, cream, sugar and vanilla bean and pulp into a pan and boil.
Soak gelatine in cold water and dissolve into the hot milk by stirring.
Divide half of the mixture into 4 glasses and leave to set for about 1 hour in the refrigerator.
Mix the remaining milk with the raspberry jam and press through a fine sieve.
Fill the glasses with the raspberry cream and return to the fridge for about 45 minutes, or until serving.
",
                HomeImageUrl = "Recipes/Panna cotta with raspberry cream.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 1,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1 egg
1 tablespoon water
1 small aubergine, cut into 1cm thick slices
120g dried breadcrumbs, seasoned
olive oil for frying
170g grated mozzarella cheese
4 tablespoons tomato pasta sauce
1/4 teaspoon crushed red chilli flakes
3 tablespoons grated Parmesan cheese
",
                Header = "Quick aubergine Parmesan",
                Content = @"In a small bowl beat the egg and water together. Place the breadcrumbs in shallow dish. Dip aubergine slices in egg mixture then in breadcrumbs, being sure to coat thoroughly.
Heat 1cm of olive oil in a large frying pan over medium-high heat until hot. Add aubergine slices and reduce heat to medium. Cook for 3 to 4 minutes per side or until golden brown and tender. Sprinkle mozzarella cheese over aubergine during last minute of cooking to melt.
While aubergine is cooking, combine pasta sauce and chilli flakes in a microwave-safe measuring jug. Cover with cling film and cook at high power for 2 minutes or until heated through.
Top aubergine with sauce and Parmesan cheese and serve.
",
                HomeImageUrl = "Recipes/Quick aubergine Parmesan.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 1,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1 sheet frozen puff pastry
225g (1/2 lb) sausage meat
5 tablespoons plain flour
1 egg, lightly beaten for glazing
",
                Header = "Rachael's sausage rolls",
                Content = @"Defrost pastry sheet, lay out onto floured surface with creases horizontal to you. With pastry or pizza cutter, cut sheet into 3 equal lengths.
Preheat oven to 250 C / Gas 8. Roll sausage into three long rolls and roll in flour, place onto separate pastry lengths. Brush edges of pastry with egg mixture.
Roll tightly into one big roll and cut each length into 6 sections. Place onto ungreased baking tray with seam side down.
Bake for 20 minutes. Cool on kitchen paper to soak up excess grease.
",
                HomeImageUrl = "Recipes/Rachael's sausage rolls.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 9,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"1 pork fillet, sliced into strips
1 onion, thinly sliced
2cm (3/4 in) piece root ginger, minced
2 cloves garlic, minced
275g (10 oz) thinly sliced pak choi
1 red pepper, sliced
10 large button mushrooms, julienned
275g (10 oz) beansprouts
4 tablespoons Chinese rice wine, or sake
3 tablespoons hoisin sauce
2 tablespoons soy sauce
8 flour tortilla wraps
",
                Header = "Mou Shu Pork Wraps",
                Content = @"Preheat oven to 160 C / Gas mark 3. Wrap tortillas in aluminium foil.
Heat a large frying pan over high heat until very hot. Add pork, onion, ginger and garlic; cook and stir until pork is brown and onion is tender, about 5 minutes. Mix in pak choi, red pepper and mushrooms; cook and stir until pepper is tender but crisp, about 5 minutes. Remove pan from heat.
Place tortillas in oven for 8 minutes, or until warm.
Meanwhile, return pan to high heat, and mix in bean sprouts, rice wine and hoisin and soy sauces; cook and stir until bean sprouts are tender, about 5 minutes.
Remove tortillas from oven. Divide pork mixture among tortillas, and roll up. Serve immediately.
",
                HomeImageUrl = "Recipes/Mou Shu Pork Wraps.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 7,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"6 tablespoons white wine vinegar
6 tablespoons vegetable oil
1 red onion, thinly sliced
4 tablespoons caster sugar
1/4 teaspoon salt
2 dashes hot sauce
ground black pepper to taste
60g coarsely chopped walnuts
1 head romaine lettuce, torn
1 head round lettuce, torn
2 bunches fresh spinach leaves
2 pears, cored and sliced
115g feta cheese
",
                Header = "Pear, walnut and feta salad",
                Content = @"In a bowl, mix the vinegar, oil, onion, sugar, salt, hot sauce and pepper. Cover and refrigerate 1 hour.
In a frying pan over medium heat, cook the walnuts, stirring constantly, until lightly toasted.
In a large bowl, mix the walnuts, romaine lettuce, round lettuce, spinach and pears. Toss with the dressing mixture to coat. Sprinkle with feta cheese to serve.
",
                HomeImageUrl = "Recipes/Pear, walnut and feta salad.jpg",
                RecipeId = id++
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 2,
                DateCreated = new DateTime(rnd.Next(2012, 2020), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(1, 12), rnd.Next(0, 59), rnd.Next(0, 59)),
                Summary = @"400g can lychee
a small bunch of mint leaves Mint mi-ntThere are several types of mint, each with its own subtle difference in flavour and appearance.â€¦
100ml vodka (or use lychee juice for a non-alcoholic version) Vodka vod-kaOriginally associated with Russia, Slavonic, Baltic and Scandinavian countries, vodka has becomeâ€¦
juice 2 limes Lime ly-mThe same shape, but smaller thanâ€¦
2 handfuls ice
",
                Header = "Frozen lychee & mint cocktails",
                Content = @"Take a can of lychees and drain the syrup into a blender. Add 4 of the lychees, a small bunch of mint leaves (reserving a few to garnish), the vodka and lime juice.
Add ice and blend until slushy. Serve in glasses garnished with a mint sprig and a lychee.
",
                HomeImageUrl = "Recipes/Frozen lychee & mint cocktails.jpg",
                RecipeId = id++
            });
        }

        void AddUserRecipePreference(Gosh.Models.MyDB context)
        {
            long ID = 1;
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 1,
                UserID = 1,
                ID = ID++
            });

            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 1,
                UserID = 1,
                ID = ID++
            });

            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 2,
                UserID = 1,
                ID = ID++
            });

            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 3,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });

            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 5,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 5,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 5,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 5,
                UserID = 1,
                ID = ID++
            });


        }
    }
}
