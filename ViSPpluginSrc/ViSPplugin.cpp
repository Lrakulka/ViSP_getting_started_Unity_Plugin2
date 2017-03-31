// ViSPplugin.cpp : Defines the exported functions for the shared library.

#include "ViSPplugin.h"

#include <visp3/core/vpPoint.h>
#include <visp3/core/vpMeterPixelConversion.h>

// Number of the output results
#define RESULTS_NUMBER 10

bool GetProjection(double oX, double oY, double oZ, double* results, int size) {

  if (size != RESULTS_NUMBER) {
	  return false;
  }
  // Construct the 3D point
  vpPoint P;
  P.set_oX(oX);
  P.set_oY(oY);
  P.set_oZ(oZ);

  results[0] = P.get_oX();
  results[1] = P.get_oY();
  results[2] = P.get_oZ();

  // Homogeneous tranformation from camera frame to object frame
  vpHomogeneousMatrix cMo(0, 0, 0.50, vpMath::rad(0), vpMath::rad(0), vpMath::rad(45));

  // Compute the position of the point in the camera frame
  P.changeFrame(cMo);

  results[3] = P.get_X();
  results[4] = P.get_Y();
  results[5] = P.get_Z();

  // Compute the perspective projection
  P.project();

  results[6] = P.get_x();
  results[7] = P.get_y();

  // Set the camera parameters for a 640x480 image
  double px = 600;
  double py = px;
  double u0 = 640/2.;
  double v0 = 480/2.;

  vpCameraParameters cam(px, py, u0, v0);

  // Compute the coordinates of the 3D point in the image
  double u, v; // u is the column, v the image row
  vpMeterPixelConversion::convertPoint(cam, P.get_x(), P.get_y(), u, v);

  results[8] = u;
  results[9] = v;
  return true;
}
