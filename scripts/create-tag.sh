git fetch --unshallow --tags

LAST_TAG="$(git describe --tags --abbrev=0)"
echo "Latest tag: $LAST_TAG"

CSPROJ_FILE_PATH="src/Yandex.Alice.Sdk/Yandex.Alice.Sdk.csproj"
CSPROJ_FILE_CONTENT="`cat $CSPROJ_FILE_PATH`"
re="<Version>(.+)<\/Version>"
if [[ $CSPROJ_FILE_CONTENT =~ $re ]]
then
    CURRENT_VERSION="${BASH_REMATCH[1]}"
    echo "Current project version from $CSPROJ_FILE_PATH: $CURRENT_VERSION"

    NEW_TAG="v$CURRENT_VERSION"
    echo "New tag could be $NEW_TAG"

    if [[ $LAST_TAG != $NEW_TAG ]]
    then
        echo "Create new tag $NEW_TAG"
        git tag $NEW_TAG
        git push origin $NEW_TAG
    else
        echo "No need to create new tag as it already exists"
    fi
else
    echo "Can't find project version from $CSPROJ_FILE_PATH"
fi
