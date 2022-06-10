# Unity Inverse Dynamics demo project

A project containing demo scenes showing off the Inverse dynamics features available with Articulation Bodies

## Counteracting Gravity forces

Use `ArticulationBody.GetJointGravityForces(List<float> forces)` to get the forces required to counteract gravity. Applying them directly will negate the effect of gravity on the Articulation. It also serves to show how much strain there is on the joints caused by gravity. 

![ID Gravity Demo](/Demo_gifs/ID_GravityForces_Demo.gif)

## Counteracting Coriolis/Centrifugal forces

Use `ArticulationBody.GetJointCoriolisCentrifugalForces(List<float> forces)` to get the forces required to counteract coriolis and centrifugal effects. Applying them directly will negate the effect of Coriolis and Centrifugal forces on the articulation. 

![ID Coriolis Applied](/Demo_gifs/ID_ApplyingCoriolisForces.gif)

Otherwise, this method can tell you what is the effect of coriolis and centrifugal forces on your articulation

![ID Coriolis Centrifugal Demo](/Demo_gifs/ID_CoriolisCentrifugal_Demo.gif)

## Getting the Articulation Drive forces

Use `ArticulationBody.GetDriveForces(List<float> forces)` to get the forces applied by each Articulation Drive in the whole articulation chain. \
Use the `ArticulationBody.driveForce` property to get the forces applied by the Articulation Drive that is attached to the body.

![ID Drive forces Demo](/Demo_gifs/ID_DriveForces_Demo.gif)

## Getting forces required to reach a specific acceleration

Use `ArticulationBody.GetJointForcesForAcceleration(ArticulationReducedSpace acceleration)` to get the forces needed to reach the provided acceleration in reduced space. This method works on the specific Articulation Body and not the whole chain. \
**Note:** The DoF count for the provided acceleration must match the DoF count of the inbound joint. (for example if the inbound joint is prismatic or revolute, the provided acceleration should also only have one DoF)

![ID Forces For acceleration](/Demo_gifs/ID_ForcesForAcceleration_Demo.gif)

## Getting the Reduced Space forces needed to counteract External forces

Use `ArticulationBody.GetJointExternalForces(List<float> forces)` to get the forces needed to counteract any previously applied forces in generalized space. This only works with forces that you've added yourself with methods like `ArticulationBody.AddForce` or `ArticulationBody.AddTorque`. 
Keep in mind that order of execution is very important. You want to make sure that all your forces are added first and only then you call the above External Forces getter. Otherwise, you may get either no forces returned or an incomplete set of forces.

![ID External Forces Demo](/Demo_gifs/ID_ExternalForces.gif)
