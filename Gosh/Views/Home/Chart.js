var yf = 2000,
    yt = 2016,
    urlCategories = 'http://localhost:49911/Categories',
    urlRecipes = 'http://localhost:49911/Recipes',
    urlUsers = 'http://localhost:49911/User';


$(document).ready(function () {

    $('#sld').slider()
        .on('slideStop', function (ev) {
            yf = parseInt(ev.value[0]);
            yt = parseInt(ev.value[1]);
            updateCharts();
        });

    updateCharts();
});

updateCharts = function () {

    obj = JSON.stringify({ yearFrom: yf, yearTo: yt, by: '' });

    var dsb = new DashboardBuilder();
    dsb.buildDashBoard({
        charts: [{
            type: 'pie', source: urlCategories, params: obj, container: 'Categories',
            charts: [{
                type: 'pie', source: urlCategories, params: obj, container: 'Categories',
                charts: [{ type: 'pie', source: urlCategories, params: obj, container: 'Categories' }]
            }]
        },
        {
            type: 'pie', source: urlUsers, params: obj, container: 'UserController',
            charts: [{
                type: 'pie', source: urlUsers, params: obj, container: 'UserController',
                charts: [{ type: 'pie', source: urlUsers, params: obj, container: 'UserController' }]
            }]
        }
        ]
    });
}
