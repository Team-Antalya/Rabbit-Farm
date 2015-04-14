#!/bin/sh
r.js -o build.js &&
cd dist &&
rm -rf .idea build.sh build.js build.txt bower.json bower.sh .bowerrc &&
mv js/libs/requirejs/require.js require.js &&
mv js/main.js main.js &&
rm -rf js/* &&
mkdir js/libs &&
mkdir js/libs/requirejs &&
mv require.js js/libs/requirejs/require.js &&
mv main.js js/main.js &&
mv css/main.css main.css &&
rm -rf css/* &&
mv main.css css/main.css