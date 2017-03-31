#include <stdio.h>
#include "ViSPplugin.h"

int main(void)
{
    printf("This is a shared library test...");
    double results[10];
    GetProjection(1, 2, 3, results, 10);
    printf("%f %f %f %f %f %f", results[0], results[1], results[2], results[3], results[4], results[5]);
    return 0;
}
