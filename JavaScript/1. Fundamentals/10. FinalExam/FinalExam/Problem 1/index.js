var test1 = '7',
    test2 = '10',
    test3 = '40';

function solve(params) {
    var s = parseInt(params[0]);

    /////////////

    var candidates = [3, 4, 10];
    var counter = 0;
    var target = s;


    function printSum(candidates, index, n) {

        for (var i = 1; i <= n; i++) {
            if (i === n) {
                counter++;
            }
        }
    }

    function solve1(target, sum, candidates, sz, index, n) {
        if (sum > target)
            return 0;
        if (sum === target)
            printSum(candidates, index, n);

        for (var i = index[n]; i < sz; i++) {
            index[n + 1] = i;
            solve1(target, sum + candidates[i], candidates, sz, index, n + 1);
        }
    }

    function solve2(target, candidates, sz) {
        var index = new Array(10000);
        index[0] = 0;
        solve1(target, 0, candidates, sz, index, 0);
    }
    solve2(target, candidates, 3)
    console.log(counter);
    ////////////
}



solve(40)






