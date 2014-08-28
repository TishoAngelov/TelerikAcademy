function(){
    var x = arguments[0],
        y = arguments[1],
        q = 0;
    if (x >  0 && y >  0) q = 1;
    if (x <  0 && y >  0) q = 2;
    if (x <  0 && y <  0) q = 3;

    console.log();
}


   